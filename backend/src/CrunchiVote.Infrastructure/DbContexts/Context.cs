using CrunchiVote.Domain.Entities;
using CrunchiVote.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CrunchiVote.Infrastructure.DbContexts;

public class Context:DbContext
{
    public  DbSet<Comment>Comments { get; set; }
    
    public  DbSet<Vote>Votes { get; set; }

    public Context()
    {
        this.Database.Migrate();
    }
    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();

            var connectionString = configuration.GetConnectionString("postgres");
          //string connectionString = "User ID=user;password=password;Server=localhost;Port=5432;Database=crunchivote;Pooling=true;Include Error Detail=true;";
            optionsBuilder.UseNpgsql(connectionString);
            this.Database.Migrate();
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CommentCfg());
        modelBuilder.ApplyConfiguration(new VoteCfg());
    }
}

