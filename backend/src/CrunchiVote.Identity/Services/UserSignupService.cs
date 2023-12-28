using CrunchiVote.Identity.Command;
using CrunchiVote.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;


namespace CrunchiVote.Identity.Services;

internal class UserSignupService : IUserSignupService
{
    private UserManager<ApplicationUser> UserManager { get; init; }

    private RoleManager<IdentityRole> RoleManager { get; init; }

    public UserSignupService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        this.UserManager = userManager;
        this.RoleManager = roleManager;
    }
 
    public async ValueTask<ResultDTO> SignUpUserAsync(UserSignupCommand command)
    {
        var user = new ApplicationUser()
        {
            UserName = command.LastName.Trim(),
            Email = command.UserName,
            FirsName= command.FirstName,
            LastName=command.LastName,
        };
        var userCreation= await this.UserManager.CreateAsync(user, command.Password);
        if (userCreation.Succeeded ) 
        {
            if(! await this.RoleManager.RoleExistsAsync(UserRoles.User))
            {
                await this.RoleManager.CreateAsync(new IdentityRole(UserRoles.User));
            }

            var res=	await this.UserManager.AddToRoleAsync(user, UserRoles.User);
				
            return new ResultDTO(res.Succeeded, "user has successfully created!");
        }

        return new ResultDTO(false, userCreation.Errors.FirstOrDefault().ToString());
    }
}