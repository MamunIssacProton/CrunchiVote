
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddTransient(interfaceType,repositoryType);
           
        }
        return services;
    }
}