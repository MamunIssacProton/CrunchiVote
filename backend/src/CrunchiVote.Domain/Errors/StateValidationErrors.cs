namespace CrunchVote.Domain.Errors;

public static class StateValidationErrors
{
    public static readonly Error InvalidArticleId = new Error("Domain.State.ArticleId","Article Id is invalid");
    
    public static readonly Error InvalidCommentMessage = new Error("Domain.State.CommentMessage","Comment message is invalid");
   
    public static readonly Error InvalidVoteId = new Error("Domain.State.VoteId","VoteId is invalid");

    public static readonly Error InvalidVoteType = new Error("Domain.State.VoteType", "Vote type is not valid");

    public static readonly Error InvalidUserName = new Error("Domain.State.UserName", "UserName is invalid");

    public static readonly Error InvalidCommentId = new Error("Domain.State.CommentId","Comment Id is invalid");
    
}