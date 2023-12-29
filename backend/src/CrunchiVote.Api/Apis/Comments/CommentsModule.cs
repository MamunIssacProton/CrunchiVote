using System.Security.Claims;
using CrunchiVote.Api.ApplicationServices;
using CrunchiVote.Api.Queries;
using Microsoft.AspNetCore.Identity;
using CrunchiVote.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CrunchiVote.Api.Apis.Comments;

public static class CommentsModule
{
    public static void RegisterCommentEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet(ApiEndpoints.PostComment, async (ClaimsPrincipal user,ApplicationService appService, int page) =>
                Results.Ok(
                    await appService.HandleQueryAsync(new GetArticlesQuery(page)))
            )
           .RequireAuthorization()
           .WithName(ApiEndpoints.PostComment).WithOpenApi();
    }
}