using System.Security.Claims;
using CrunchiVote.Api.ApplicationServices;
using CrunchiVote.Api.Queries;
using Microsoft.AspNetCore.Identity;
using CrunchiVote.Identity;
using Microsoft.AspNetCore.Authorization;
using CrunchiVote.Api.Commands;
using CrunchVote.Domain;

namespace CrunchiVote.Api.Apis.Comments;

public static class CommentsModule
{
    public static void RegisterCommentEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(ApiEndpoints.PostComment, async (ClaimsPrincipal user, ApplicationService appService, AddCommentCommand command) =>
                Result.SucessWithData(

                    await appService.HandleCommandAsync(command,user.Identity.Name))
            )
           .RequireAuthorization()
           .WithName(ApiEndpoints.PostComment).WithOpenApi();

       
        endpoints.MapGet(ApiEndpoints.GetCommentsById,  async (ApplicationService appService,int articleId) => 
                Result.SucessWithData(
                    await appService.HandleQueryAsync(articleId)
            ))
            .WithName(ApiEndpoints.GetCommentsById).WithOpenApi();
    }
}