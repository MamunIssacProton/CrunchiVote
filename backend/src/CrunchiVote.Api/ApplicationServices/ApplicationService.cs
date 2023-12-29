using System.ComponentModel;
using CruchiVote.Service.Interface;
using CruchiVote.Service.Interfaces;
using CrunchiVote.Api.Commands;
using CrunchiVote.Api.Queries;
using CrunchiVote.Domain.Entities;
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
    
    public ApplicationService(
            ResiliencePipelineProvider<string> resiliencePipelineProvider,
            INewsArticleService articleService,
            ICommentService commentService
        )
    {
        this.ResiliencePipelineProvider = resiliencePipelineProvider;
        this.ArticleService = articleService;
        this.CommentService = commentService;
     
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

  
}