using CrunchiVote.Shared.DTOs;
using CrunchVote.Shared.FallBackData;
using Polly;
using Polly.Fallback;

namespace CrunchiVote.Api;

internal static class ResilientPipeline
{
    internal static IServiceCollection AddResiliency(this IServiceCollection services)
    {
        services.AddResiliencePipeline<string,List<ArticleDTO>>(Fallbacks.ArticleFallBack, pipelineBuilder =>
        {
            pipelineBuilder.AddFallback(new FallbackStrategyOptions<List<ArticleDTO>>
            {
       
                FallbackAction = _=>Outcome.FromResultAsValueTask<List<ArticleDTO>>(ArticleFallBack.Empty)
            });
        });


        return services;
    }
}