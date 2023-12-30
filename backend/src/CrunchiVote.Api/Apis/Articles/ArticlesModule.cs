using CrunchiVote.Api.ApplicationServices;
using CrunchiVote.Api.Queries;
using CrunchVote.Domain;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CrunchiVote.Api.Apis;

public static class ArticlesModule
{
    public static void RegisterArticlesEndpoints(this IEndpointRouteBuilder endpoints)
    {
        
        endpoints.MapGet(ApiEndpoints.Articles, async (ApplicationService appService, int page) =>
                
                        page.IsValidAsPageNumber()? Result.SucessWithData(await appService.HandleQueryAsync(new GetArticlesQuery(page)))
                            :Result.Failure(InputErrors.InvalidPageNumber))
                 .WithName(ApiEndpoints.Articles).WithOpenApi();
    }
}