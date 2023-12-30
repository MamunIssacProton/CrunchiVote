using System.Security.Claims;
using CrunchiVote.Api.ApplicationServices;
using CrunchiVote.Api.Commands;
using CrunchiVote.Api.InputValidators;
using CrunchVote.Domain;

namespace CrunchiVote.Api.Apis.Vote;

public static class VoteModule
{
    public static void RegisterVoteEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(ApiEndpoints.AddVoteOnComment,
                async (ClaimsPrincipal user, ApplicationService appService, AddVoteCommand command) =>
                {
                    var validationResult = command.Validate();
                    return validationResult.IsSuccess
                        ? Result.SucessWithData(await appService.HandleCommandAsync(command, user.Identity.Name))
                        : validationResult;
                }
            )
            .RequireAuthorization()
            .WithName(ApiEndpoints.AddVoteOnComment).WithOpenApi();

       
        endpoints.MapGet(ApiEndpoints.GetVotesByCommentId,  async (ApplicationService appService,Guid commentId) => 
                 commentId.IsValidAsCommentId()? Result.SucessWithData(
                    await appService.HandleQueryAsync(commentId)): InputErrors.InvalidCommentId)
                 .WithName(ApiEndpoints.GetVotesByCommentId).WithOpenApi();
    }
}