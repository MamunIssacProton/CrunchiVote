using System.Collections.Immutable;
using CrunchiVote.Domain.Entities;
using CrunchiVote.Identity;
using CrunchiVote.Infrastructure.DbContexts;
using CrunchiVote.Infrastructure.Interfaces;
using CrunchiVote.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

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

     public async ValueTask<List<CommentDTO>> GetCommentsByArticleIdAsync(int articleId)
     {
       var d= await this.Context.Comments.AsNoTracking().Include(x=>x.Votes).ToListAsync();
            
        return  d.Where(x=>x.ArticleId==articleId).Select(x => new CommentDTO(x.Id, x.UserName, x.Message,x.Votes.Select(v=>new VoteDTO(v.CommentId,v.Id,v.GivenBy,v.VoteType)).ToList())).ToList();
     }
}