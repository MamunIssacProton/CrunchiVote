
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("CrunchiVote.Api")]
namespace CrunchiVote.Identity.Interfaces;

internal interface IUserLoginService
{
    internal ValueTask<AuthDTO> LoginUserAsync(string username, string password);
}