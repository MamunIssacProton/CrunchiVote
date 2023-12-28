using System.ComponentModel;
using CruchiVote.Service.Features.GetArticles.Interface;
using CrunchiVote.Api.Commands;
using CrunchiVote.Api.Queries;
using CrunchiVote.Domain.Entities;
using CrunchiVote.Identity.Interfaces;
using CrunchiVote.Shared.DTOs;
using Polly;
using Polly.Registry;
using UserSignupCommand = CrunchiVote.Identity.Command.UserSignupCommand;

namespace CrunchiVote.Api.ApplicationServices;

internal class ApplicationService
{
    private readonly INewsArticleService ArticleService;
    private readonly ResiliencePipelineProvider<string> ResiliencePipelineProvider;

    private readonly IUserSignupService SignupService;
    private readonly IUserLoginService LoginService;
    public ApplicationService(INewsArticleService articleService,
        ResiliencePipelineProvider<string> resiliencePipelineProvider ,
        IUserSignupService userSignupService,
        IUserLoginService userLoginService
        )
    {

        this.ArticleService = articleService;
        this.ResiliencePipelineProvider = resiliencePipelineProvider;
        this.SignupService = userSignupService;
        this.LoginService = userLoginService;
    }

    internal async ValueTask<List<ArticleDTO>> HandleQueryAsync(GetArticlesQuery query)
    {
        var pipeline = this.ResiliencePipelineProvider.GetPipeline<List<ArticleDTO>>(Fallbacks.ArticleFallBack);
        return await pipeline.ExecuteAsync(async ct =>
        
            await this.ArticleService.GetArticlesAsync(query.page),new CancellationToken()
        );
      
    }

    internal async ValueTask<IResult> HandleCommandAsync(UserSignupCommand command)
    {
        return   Results.Ok(await this.SignupService.SignUpUserAsync(command));

        
    }


    internal async ValueTask<IResult> HandleCommandAsync(string username, string password)
    {
        return Results.Ok(await this.LoginService.LoginUserAsync(username, password));
    }
}