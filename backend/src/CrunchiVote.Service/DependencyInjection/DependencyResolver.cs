using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CruchiVote.Service.DependencyInjection;

public static class DependencyResolver
{
    public static IServiceCollection ResolveServiceDependencies(this IServiceCollection services)
    {
        var serviceTypes =  Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type => type.IsClass
                           && !type.IsAbstract 
                           && typeof(IBaseService).IsAssignableFrom(type)
            );

        foreach (var serviceType in serviceTypes)
        {
            var interfaceType = serviceType.GetInterfaces().FirstOrDefault(i => i != typeof(IBaseService));
            if (interfaceType is null)
                continue;
            services.TryAddScoped(interfaceType,serviceType);
           
        }
        return services;
    }
}