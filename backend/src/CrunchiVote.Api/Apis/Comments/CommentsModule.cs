using System.Security.Claims;
using CrunchiVote.Api.ApplicationServices;
using CrunchiVote.Api.Commands;
using CrunchiVote.Api.InputValidators;
using CrunchVote.Domain;
namespace CrunchiVote.Api.Apis.Comments;

public static class CommentsModule
{
    public static void RegisterCommentEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(ApiEndpoints.PostComment,
                async (ClaimsPrincipal user, ApplicationService appService, AddCommentCommand command) =>
                {
                    var validationResult = command.Validate();
                    return validationResult.IsSuccess
                        ? Result.SucessWithData(await appService.HandleCommandAsync(command, user.Identity.Name))
                        : validationResult;

                } 
            )
           .RequireAuthorization()
           .WithName(ApiEndpoints.PostComment).WithOpenApi();

       
        endpoints.MapGet(ApiEndpoints.GetCommentsById,  async (ApplicationService appService,int articleId) =>
            {
                return articleId.IsValidAsArticleId()
                    ? Result.SucessWithData(
                        await appService.HandleQueryAsync(articleId)
                    )
                    : InputErrors.InvalidArticleId;
            })
            .WithName(ApiEndpoints.GetCommentsById).WithOpenApi();
    }
}