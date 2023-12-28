
using System.Runtime.CompilerServices;
using CrunchiVote.Identity.Command;
[assembly:InternalsVisibleTo("CrunchiVote.Api")]
namespace CrunchiVote.Identity.Interfaces;

internal interface IUserSignupService
{
    internal ValueTask<ResultDTO> SignUpUserAsync(UserSignupCommand command);
}