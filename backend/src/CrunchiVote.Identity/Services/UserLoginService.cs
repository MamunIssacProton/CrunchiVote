using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CrunchiVote.Identity.ExtensionMethods;
using CrunchiVote.Identity.Interfaces;
using CrunchiVote.Identity.Options;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CrunchiVote.Identity.Services;

internal class UserLoginService : IUserLoginService
{
    private readonly UserManager<ApplicationUser> UserManager;
    private readonly IConfiguration Configuration;
 
   
    public UserLoginService(
                        UserManager<ApplicationUser> userManager,
                        IConfiguration configuration)
    {
       
        this.UserManager = userManager;
   
        this.Configuration = configuration;
    }

    public async ValueTask<AuthDTO> LoginUserAsync(string username, string password)
    {
        var user = await UserManager.FindByEmailAsync(username);

        if (user == null || !await UserManager.CheckPasswordAsync(user, password))
        {
            return new AuthDTO(false, "Authentication Failed!");
        }

        var roles = await UserManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        
        var jwtOptions = Configuration.GetSection("JwtOptions").Get<JwtOptions>();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            Configuration["JwtOptions:Issuer"],
            Configuration["JwtOptions:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(Configuration["JwtOptions:ExpiryInMinutes"])),
            signingCredentials: credentials
        );

        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
        var authState = new AuthenticationState(token.GetClaimsPrincipal());
       
        return new AuthDTO(true,"login successful!", accessToken);

    }
}