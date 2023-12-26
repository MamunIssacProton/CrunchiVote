using CruchiVote.Service.DependencyInjection;
using CrunchiVote.Api.ApplicationServices;
using CrunchiVote.Api.ExceptionHanlder;
using CrunchiVote.Api.Options;
using CrunchiVote.Api.Queries;
using CrunchiVote.Infrastructure.DependencyInjection;
using CrunchiVote.Shared.DTOs;
using CrunchiVote.Shared.Utils;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Fallback;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureOptions<TechCrunchClientOptionsSetup>();
builder.Services.AddHttpClient(HttpClientsName.TechCrunch, (serviceProvider, httpClient) =>
{
    var option = serviceProvider.GetRequiredService<IOptions<TechCrunchClientOptions>>()!.Value;
    httpClient.BaseAddress = new Uri(option.EndpointUrl);
});

builder.Services.ResolveRepositoryDependencies();
builder.Services.ResolveServiceDependencies();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.TryAddScoped<ApplicationService>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

//add polly for ensuring resiliency
builder.Services.AddResiliencePipeline<string,List<ArticleDTO>>("article-fallback", pipelineBuilder =>
{
    pipelineBuilder.AddFallback(new FallbackStrategyOptions<List<ArticleDTO>>
    {
       
        FallbackAction = _=>Outcome.FromResultAsValueTask<List<ArticleDTO>>(Artcls.Empty)
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("articles",  async (ApplicationService appService,int page) => 
             Results.Ok(
                            await appService.HandleQueryAsync(new GetArticlesQuery(page)))
                        )
    .WithName("get articles").WithOpenApi();
app.UseExceptionHandler();
app.Run();
