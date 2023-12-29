using CrunchVote.Domain.Enums;

namespace CrunchiVote.Api.Commands;

public class AddVoteCommand
{
    public Guid CommentId { get; set; }
    
    public  VoteType VoteType { get; set; }
}