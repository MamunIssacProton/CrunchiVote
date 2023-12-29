using System.ComponentModel;
using CruchiVote.Service.Features.GetArticles.Interface;
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
    private  readonly IComm
    
    public ApplicationService(INewsArticleService articleService,
            ResiliencePipelineProvider<string> resiliencePipelineProvider 
   
        )
    {

        this.ArticleService = articleService;
        this.ResiliencePipelineProvider = resiliencePipelineProvider;
     
    }

    internal async ValueTask<List<ArticleDTO>> HandleQueryAsync(GetArticlesQuery query)
    {
        var pipeline = this.ResiliencePipelineProvider.GetPipeline<List<ArticleDTO>>(Fallbacks.ArticleFallBack);
        return await pipeline.ExecuteAsync(async ct =>
        
            await this.ArticleService.GetArticlesAsync(query.page),new CancellationToken()
        );
      
    }

  
}