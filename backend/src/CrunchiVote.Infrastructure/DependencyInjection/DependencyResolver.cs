
using System.Reflection;
using System.Runtime.CompilerServices;
using CrunchiVote.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

[assembly:InternalsVisibleTo("CrunchiVote.Api")]
namespace CrunchiVote.Infrastructure.DependencyInjection;

public static class DependencyResolver
{
    public static IServiceCollection ResolveRepositoryDependencies(this IServiceCollection services)
    {
        var repositoryTypes =  Assembly.GetExecutingAssembly()
                                                        .GetTypes()
                                                        .Where(type => type.IsClass
                                                                       && !type.IsAbstract 
                                                                       && typeof(IBaseRepository).IsAssignableFrom(type)
                                                        );

        foreach (var repositoryType in repositoryTypes)
        {
            var interfaceType = repositoryType.GetInterfaces().FirstOrDefault(i => i != typeof(IBaseRepository));
            if (interfaceType is null)
                continue;
            services.TryAddScoped(interfaceType,repositoryType);
           
        }
        return services;
    }

   
}