using CrunchiVote.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrunchiVote.Infrastructure.Configurations;

public class VoteCfg: IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new {x.CommentId, x.GivenBy});
        builder.HasOne<Comment>().WithMany(x=>x.Votes).HasForeignKey(x=>x.CommentId);
        builder.Property(x => x.VoteType);
        builder.Ignore(x => x.version);
        
    }
}