using System.ComponentModel;
using CruchiVote.Service.Interface;
using CruchiVote.Service.Interfaces;
using CrunchiVote.Api.Commands;
using CrunchiVote.Api.Queries;
using CrunchiVote.Domain.Entities;
using CrunchiVote.Service.Interfaces;
using CrunchiVote.Shared.DTOs;
using Polly;
using Polly.Registry;
using UserSignupCommand = CrunchiVote.Identity.Command.UserSignupCommand;

namespace CrunchiVote.Api.ApplicationServices;

internal class ApplicationService
{
    private readonly INewsArticleService ArticleService;
    private readonly ResiliencePipelineProvider<string> ResiliencePipelineProvider;
    private  readonly ICommentService CommentService;
    private readonly IVoteService VoteService;
    public ApplicationService(
            ResiliencePipelineProvider<string> resiliencePipelineProvider,
            INewsArticleService articleService,
            ICommentService commentService,
            IVoteService voteService
        )
    {
        this.ResiliencePipelineProvider = resiliencePipelineProvider;
        this.ArticleService = articleService;
        this.CommentService = commentService;
        this.VoteService = voteService;
    }

    internal async ValueTask<List<ArticleDTO>> HandleQueryAsync(GetArticlesQuery query)
    {
        var pipeline = this.ResiliencePipelineProvider.GetPipeline<List<ArticleDTO>>(Fallbacks.ArticleFallBack);
        return await pipeline.ExecuteAsync(async ct =>
             await this.ArticleService.GetArticlesAsync(query.page),new CancellationToken()
        );
      
    }


    internal async ValueTask<ResultDTO> HandleCommandAsync(AddCommentCommand command, string userName)
    {
        var comment = new Comment(Guid.NewGuid());
        comment.AddUserName(userName);
        comment.AddArticleId(command.ArticleId);
        comment.AddCommentMessage(command.Message);
       
        return await this.CommentService.AddCommentOnArticleAsync(comment);
    }

    internal async ValueTask<ResultDTO> HandleCommandAsync(AddVoteCommand command,string username)
    {
        var vote = new Vote(Guid.NewGuid());
        vote.AddUsername(username);
        vote.AddCommentId(command.CommentId);
        vote.AddVoteType(command.VoteType);
        return await this.VoteService.AddVoteOnCommentAsync(vote);
    }
    internal async ValueTask<List<CommentDTO>> HandleQueryAsync(int id) =>
        await this.CommentService.GetCommentsByArticleIdAsync(id);

    internal async ValueTask<List<VoteDTO>> HandQueryAsync(Guid commentId) =>
        await this.VoteService.GetVotesByCommentId(commentId);

    internal async ValueTask<ResultDTO> HandleQueryAsync(IsEligibleForVoteQuery query,string username)
    {
       return await this.VoteService.IsEligibleForVote(username, query.CommentId, query.VoteType);
    }
    
}