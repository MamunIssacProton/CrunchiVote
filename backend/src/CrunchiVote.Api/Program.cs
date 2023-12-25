using CrunchiVote.Api.Options;
using CrunchiVote.Infrastructure.DependencyInjection;
using CrunchiVote.Infrastructure.Features.GetArticles.Interfaces;
using CrunchiVote.Shared.Utils;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureOptions<TechCrunchClientOptionsSetup>();
builder.Services.AddHttpClient(HttpClientsName.TechCrunch, (serviceProvider, httpClient) =>
{
    var option = serviceProvider.GetRequiredService<IOptions<TechCrunchClientOptions>>()!.Value;
    httpClient.BaseAddress = new Uri(option.EndpointUrl);
});

builder.Services.ResolveRepositoryDependencies();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("articles/{page:int}", GetArticles).WithName("get articles").WithOpenApi();

// Define a method for handling the GET request
 object GetArticles(INewsArticleRepository repo, int page=1)
{
    var articles = repo.GetArticlesAsync(page: page);
    return Results.Ok(articles);
}

app.Run();
