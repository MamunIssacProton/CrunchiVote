
using CruchiVote.Service.Features.AddComments.Interfaces;
using CrunchiVote.Domain.Entities;
using CrunchiVote.Identity;
using CrunchiVote.Infrastructure.Features.AddComments.Interfaces;
using CrunchiVote.Shared.DTOs;

namespace CruchiVote.Service.Features.AddComments.Services;

internal class CommentService : ICommentService
{
    private readonly ICommentsRepository CommentsRepository;

    public CommentService(ICommentsRepository commentsRepository) => this.CommentsRepository = commentsRepository;

    public async ValueTask<ResultDTO> AddCommentOnArticleAsync(Comment comment)=>await this.CommentsRepository.AddCommentOnArticleAsync(comment);

}