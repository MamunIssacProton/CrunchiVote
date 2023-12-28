namespace CrunchiVote.Api.Commands;

public record UserLoginCommand
{
    public required string Username { get; set; }
    public  required  string Password { get; set; }
}