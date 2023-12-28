using CruchiVote.Domain.ValueObjects;
using CrunchiVote.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrunchiVote.Infrastructure.Configurations;

internal class UserConf : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.UserName);
        builder.OwnsOne(x => x.FirstName).Property(x => x.Value);
        builder.OwnsOne(x => x.LastName).Property(x => x.Value);
       
        builder.Ignore(x => x.version);
      
    }
  
}