using System.Runtime.CompilerServices;
using CrunchiVote.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CrunchiVote.Identity;

internal class IdentityContext : IdentityDbContext<ApplicationUser>
{
    public IdentityContext()
    {
        this.Database.Migrate();
    }
    public IdentityContext(DbContextOptions<IdentityContext> options):base(options)
    {
            
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = "User ID=user;password=password;Server=localhost;Port=5432;Database=crunchivote;Pooling=true;Include Error Detail=true;";
           
            optionsBuilder.UseNpgsql(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ApplicationUser>().ToTable("CrunchiVoteUsers");
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUser<string>>().ToTable("Users");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        builder.Entity<IdentityUserClaim<string>>().ToTable("Claims");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        builder.Entity<IdentityUserToken<string>>().ToTable("Tokens");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("UserRoleClaims");
        

    }
}