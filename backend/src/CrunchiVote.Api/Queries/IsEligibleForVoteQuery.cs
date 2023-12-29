using CrunchVote.Domain.Enums;

namespace CrunchiVote.Api.Queries;

public class IsEligibleForVoteQuery
{
    public  Guid CommentId { get; set; }

    public VoteType VoteType { get; set; }
}