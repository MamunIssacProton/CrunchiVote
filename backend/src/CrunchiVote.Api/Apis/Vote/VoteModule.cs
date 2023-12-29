using System.Security.Claims;
using CrunchiVote.Api.ApplicationServices;
using CrunchiVote.Api.Commands;

namespace CrunchiVote.Api.Apis.Vote;

public static class VoteModule
{
    public static void RegisterVoteEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(ApiEndpoints.AddVoteOnComment, async (ClaimsPrincipal user, ApplicationService appService, AddVoteCommand command) =>
                Results.Ok(

                    await appService.HandleCommandAsync(command,user.Identity.Name))
            )
            .RequireAuthorization()
            .WithName(ApiEndpoints.AddVoteOnComment).WithOpenApi();

       
        endpoints.MapGet(ApiEndpoints.GetVotesByCommentId,  async (ApplicationService appService,int commentId) => 
                Results.Ok(
                    await appService.HandleQueryAsync(commentId)
                ))
            .WithName(ApiEndpoints.GetVotesByCommentId).WithOpenApi();
    }
}