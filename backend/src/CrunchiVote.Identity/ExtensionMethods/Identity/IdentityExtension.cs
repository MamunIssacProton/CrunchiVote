using System.Runtime.CompilerServices;
using System.Text;

using CrunchiVote.Identity;
using CrunchiVote.Identity.Interfaces;
using CrunchiVote.Identity.Options;
using CrunchiVote.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

[assembly:InternalsVisibleTo("CrunchiVote.Api")]
namespace CrunchiVote.Identity.ExtensionMethods;

internal static class IdentityExtension
{
    internal static IServiceCollection AddIdentities(this IServiceCollection services)
    {   
        services.ConfigureOptions<DbOptionSetup>();
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        
        services.AddAuthentication(options=>
                                {
                                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                                })
                 .AddJwtBearer(IdentityConstants.BearerScheme, options =>
                 {
                     var jwtOptions = configuration.GetSection("JwtOptions").Get<JwtOptions>();

                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         ValidIssuer = jwtOptions.Issuer,
                         ValidAudience = jwtOptions.Audience,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                         ClockSkew = TimeSpan.Zero 
                     };
                 });

        
        
        services.AddAuthorization(options =>
        {
            options.AddPolicy("User", policy => policy.RequireRole("user"));
        });
        services.AddAuthorizationBuilder();

        services.AddDbContext<IdentityContext> ((serviceProvider,x) =>
        {
            var option=serviceProvider.GetService<IOptions<DbOptions>> ()!.Value;
            x.UseNpgsql(option.ConnectionString,serverActionOption=>
            {
                serverActionOption.EnableRetryOnFailure(option.MaxRetryCount);
                serverActionOption.CommandTimeout(option.CommandTimeOut);

            });
            x.EnableDetailedErrors(option.EnableDetailedErrors);
            x.EnableSensitiveDataLogging(option.EnableSensitiveDataLogging);
        },ServiceLifetime.Singleton);

        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddApiEndpoints();
        
        
        ///add CrunchiVote IdendentySerivices
        
        services.TryAddScoped<IUserLoginService,UserLoginService>();
        services.TryAddScoped<IUserSignupService,UserSignupService>();
        
        return services;
    }
    
    
}