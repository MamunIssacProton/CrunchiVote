using System.Threading.RateLimiting;

namespace CrunchiVote.Api;

internal  static class RateLimitBasedOnClientIP
{
    public static IServiceCollection AddClientIpRateLimiter(this IServiceCollection services)
    {
        return services.AddRateLimiter(options =>
        {

            options.AddPolicy(Literal.RateLimitFixedByClientIp, httpContext =>
                RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: httpContext.Connection.RemoteIpAddress?.ToString(),
                    factory: _ => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = 15,
                        Window = TimeSpan.FromMinutes(1)
                    }));

        });
    }
    
}