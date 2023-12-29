using CruchiVote.Service.Interfaces;
using CrunchiVote.Domain.Entities;
using CrunchiVote.Identity;
using CrunchiVote.Infrastructure.Interfaces;
using CrunchiVote.Shared.DTOs;

namespace CruchiVote.Service.Services;

internal class CommentService :ICommentService
{
    private readonly ICommentsRepository CommentsRepository;

    
    public CommentService(ICommentsRepository commentsRepository) => 
                          this.CommentsRepository = commentsRepository;

    async ValueTask<ResultDTO> ICommentService.AddCommentOnArticleAsync(Comment comment)=>
                               await this.CommentsRepository.AddCommentOnArticleAsync(comment);

}