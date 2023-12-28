using CrunchiVote.Api.ApplicationServices;
using CrunchiVote.Api.Commands;
using CrunchiVote.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using UserSignupCommand = CrunchiVote.Identity.Command.UserSignupCommand;

namespace CrunchiVote.Api.Apis;

public static class UsersModule
{
    public static void RegisterUsersEndpoints(this IEndpointRouteBuilder endpoints)
    {
        
        endpoints.MapPost(ApiEndpoints.RegisterUser,  async (ApplicationService appService,UserSignupCommand command) => 
             
                    await appService.HandleCommandAsync(command)
            )
            .WithName(ApiEndpoints.RegisterUser).WithOpenApi();
        
        
        endpoints.MapPost(ApiEndpoints.LoginUser,  async (ApplicationService appService,UserLoginCommand command) => 
             
               Results.Ok(await appService.HandleCommandAsync(command.Username,command.Password))
            )
            .WithName(ApiEndpoints.LoginUser).WithOpenApi();
    }
}