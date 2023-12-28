using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CrunchiVote.Identity.Options;

internal class DbOptionSetup : IConfigureOptions<DbOptions>
{
    private readonly IConfiguration Configuration;
    public DbOptionSetup(IConfiguration configuration)=> this.Configuration = configuration;
   
    public void Configure(DbOptions options)
    {
        options.ConnectionString = this.Configuration.GetConnectionString("postgres")!;
        this.Configuration.GetSection("DbOptions").Bind(options);
    }
}