using System.Collections.Immutable;
using CrunchiVote.Domain.Entities;
using CrunchiVote.Identity;
using CrunchiVote.Infrastructure.DbContexts;
using CrunchiVote.Infrastructure.Interfaces;
using CrunchiVote.Shared.DTOs;

namespace CrunchiVote.Infrastructure.Repositories;
public  class Commentsrepository :ICommentsRepository
{
    private readonly Context Context;
   
    public Commentsrepository(Context context) => this.Context = context;
    
     async ValueTask<ResultDTO> ICommentsRepository.AddCommentOnArticleAsync(Comment comment)
    {
        await this.Context.Comments.AddAsync(comment);
        await this.Context.SaveChangesAsync();
        return new ResultDTO(true,$"{comment.Message.Value} has successfully added on article id  {comment.ArticleId.Value}");
    }
}