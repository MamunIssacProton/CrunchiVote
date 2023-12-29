using System.Collections.Immutable;
using CrunchiVote.Domain.Entities;
using CrunchiVote.Identity;
using CrunchiVote.Infrastructure.DbContexts;
using CrunchiVote.Infrastructure.Features.AddComments.Interfaces;

namespace CrunchiVote.Infrastructure.Features.AddComments.Repositories;
internal sealed class Commentsrepository :ICommentsRepository
{
    private readonly Context Context; 
    
    internal Commentsrepository(Context context) => this.Context = context;
    
    public  async ValueTask<ResultDTO> AddCommentOnArticleAsync(Comment comment)
    {
        await this.Context.Comments.AddAsync(comment);
        await this.Context.SaveChangesAsync();
        return new ResultDTO(true,$"{comment.Message.Value} has successfully added on article id  {comment.ArticleId.Value}");
    }
}