using System.Runtime.CompilerServices;
using CrunchiVote.Identity.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

[assembly:InternalsVisibleTo("CrunchiVote.Api")]
namespace CrunchiVote.Identity.ExtensionMethods;

internal static class IdentityExtension
{
    
    internal static IServiceCollection AddIdentities(this IServiceCollection services)

    {
        services.ConfigureOptions<DbOptionSetup>();
        
        services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
        services.AddAuthorizationBuilder();
        services.AddDbContext<IdentityContext> ((serviceProvider,x) =>
        {
            var option=serviceProvider.GetService<IOptions<DbOptions>> ()!.Value;
           // x.UseNpgsql("User ID=user;password=password;Server=localhost;Port=5432;Database=crunchivote;Pooling=true;Include Error Detail=true;");
            x.UseNpgsql(option.ConnectionString,serverActionOption=>
            {
                serverActionOption.EnableRetryOnFailure(option.MaxRetryCount);
                serverActionOption.CommandTimeout(option.CommandTimeOut);
            
            });
            x.EnableDetailedErrors(option.EnableDetailedErrors);
            x.EnableSensitiveDataLogging(option.EnableSensitiveDataLogging);
        },ServiceLifetime.Singleton);

        services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddApiEndpoints();
        
       
        return services;
    }
    
}