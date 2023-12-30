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
                        page<1? Result.Failure(InputErrors.InvalidPageNumber): 
                                Result.SucessWithData(await appService.HandleQueryAsync(new GetArticlesQuery(page))))
                 .WithName(ApiEndpoints.Articles).WithOpenApi();
    }
}