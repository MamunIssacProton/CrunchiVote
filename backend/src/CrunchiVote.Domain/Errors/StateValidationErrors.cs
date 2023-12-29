namespace CrunchVote.Domain.Errors;

public static class StateValidationErrors
{
    public static readonly Error InvalidVoteType = new Error("State.VoteType", "Vote type is not valid");

    public static readonly Error InvalidUserName = new Error("State.UserName", "UserName is invalid");

    public static readonly Error InvalidCommentId = new Error("State.CommentId","Comment Id is invalid");
    
}