using CruchiVote.Service.DependencyInjection;
using CrunchiVote.Api;
using CrunchiVote.Api.Apis;
using CrunchiVote.Api.Apis.Comments;
using CrunchiVote.Api.Apis.Vote;
using CrunchiVote.Api.ApplicationServices;
using CrunchiVote.Api.ExceptionHanlder;

using CrunchiVote.Api.Options;
using CrunchiVote.Api.Queries;
using CrunchiVote.Identity;
using CrunchiVote.Identity.ExtensionMethods;
using CrunchiVote.Infrastructure.DependencyInjection;
using CrunchiVote.Shared.DTOs;
using CrunchiVote.Shared.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Fallback;

var builder = WebApplication.CreateBuilder(args);
// register options with validation
builder.Services.AddOptions<TechCrunchClientOptions>()
                .BindConfiguration(ConfigSection.TechCrunchClientOptions)
                .ValidateDataAnnotations().ValidateOnStart();

// add TechCrunch as http client 
builder.Services.AddHttpClient(HttpClientsName.TechCrunch, (serviceProvider, httpClient) =>
{
    var option = serviceProvider.GetRequiredService<IOptions<TechCrunchClientOptions>>()!.Value;
    httpClient.BaseAddress = new Uri(option.EndpointUrl);
});

//resolve dependencies
builder.Services.AddDbContext<CrunchiVote.Infrastructure.DbContexts.Context>((options =>
{

    options.UseNpgsql(builder.Configuration.GetConnectionString("postgres"));
}), ServiceLifetime.Scoped);
builder.Services.ResolveRepositoryDependencies();
builder.Services.ResolveServiceDependencies();
builder.Services.TryAddScoped<ApplicationService>();

//api explorer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add Global Exception handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();


//add polly for ensuring resiliency
builder.Services.AddResiliency();

//add rate limiter
builder.Services.AddClientIpRateLimiter();

// add api response compression
builder.Services.AddCompression();

builder.Services.AddIdentities();

builder.Services.AddOptions();
builder.Services.AddAntiforgery();
builder.Services.AddControllersWithViews();


//enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "frontend",
        policy => policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());;
});

var app = builder.Build();

app.UseCors("frontend");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

/// register api endpoints
app.RegisterArticlesEndpoints();

app.RegisterCommentEndpoints();
app.RegisterVoteEndpoints();



app.MapIdentityApi<ApplicationUser>();
app.UseExceptionHandler();
app.UseRateLimiter();
app.Run();
