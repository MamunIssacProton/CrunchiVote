using CrunchiVote.Api.ApplicationServices;
using CrunchiVote.Api.Queries;

namespace CrunchiVote.Api.Apis;

public static class ArticlesModule
{
    public static void RegisterArticlesEndpoints(this IEndpointRouteBuilder endpoints)
    {
        
        endpoints.MapGet("articles",  async (ApplicationService appService,int page) => 
                Results.Ok(
                    await appService.HandleQueryAsync(new GetArticlesQuery(page)))
            )
            .WithName("articles").WithOpenApi();
    }
}