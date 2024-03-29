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
       
            string connectionString = "User ID=user;password=password;Server=localhost;Port=5432;Database=crunchivote;Pooling=true;Include Error Detail=true;";
            optionsBuilder.UseNpgsql(connectionString);
            
        
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CommentCfg());
        modelBuilder.ApplyConfiguration(new VoteCfg());
    }
}

