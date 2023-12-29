using CrunchiVote.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrunchiVote.Infrastructure.Configurations;

internal class CommentCfg : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.UserName);
        builder.OwnsOne(x => x.Message).Property(x => x.Value).HasColumnName("Message");
        builder.OwnsOne(x => x.ArticleId).Property(x=>x.Value).HasColumnName("ArticleId");
        
        builder.Ignore(x => x.version);
    }
}