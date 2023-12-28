using Microsoft.AspNetCore.Identity;

namespace CrunchiVote.Identity;

internal class ApplicationUser : IdentityUser
{
    internal string FirsName { get; set; }
    
    internal string LastName { get; set; }
    
}