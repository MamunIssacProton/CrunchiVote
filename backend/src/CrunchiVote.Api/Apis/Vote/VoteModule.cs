using System.Security.Claims;
using CrunchiVote.Api.ApplicationServices;
using CrunchiVote.Api.Commands;
using CrunchVote.Domain;

namespace CrunchiVote.Api.Apis.Vote;

public static class VoteModule
{
    public static void RegisterVoteEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(ApiEndpoints.AddVoteOnComment, async (ClaimsPrincipal user, ApplicationService appService, AddVoteCommand command) =>
                Result.SucessWithData(

                    await appService.HandleCommandAsync(command,user.Identity.Name))
            )
            .RequireAuthorization()
            .WithName(ApiEndpoints.AddVoteOnComment).WithOpenApi();

       
        endpoints.MapGet(ApiEndpoints.GetVotesByCommentId,  async (ApplicationService appService,int commentId) => 
                Result.SucessWithData(
                    await appService.HandleQueryAsync(commentId)
                ))
            .WithName(ApiEndpoints.GetVotesByCommentId).WithOpenApi();
    }
}