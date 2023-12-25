using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CrunchiVote.Api.Options;

public class TechCrunchClientOptionsSetup:IConfigureOptions<TechCrunchClientOptions>
{
    private readonly IConfiguration Configuration;

    public TechCrunchClientOptionsSetup(IConfiguration configuration) => this.Configuration = configuration;
    public void Configure(TechCrunchClientOptions options)
    {
        this.Configuration.GetSection("TechCrunchClientOptions").Bind(options);
    }
}