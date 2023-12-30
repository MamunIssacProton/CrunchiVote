using CrunchVote.Domain;

namespace CrunchiVote.Api;

public static class InputErrors
{
    public static readonly Error InvalidPageNumber = new Error("Api.Input.PageNumber", "Page number is invalid");

    public static readonly Error InvalidCommentId = new Error("Api.Input.CommentId", "Comment Id is invalid");

    public static readonly Error InvalidComment = new Error("Api.Input.Comment",  "Comment is invalid");

    public static readonly Error InvalidVoteType = new Error("Api.Input.VoteType", "Vote Type is invalid, you cannot select except UpVote or DownVote");

    public static readonly Error InvalidArticleId = new Error("Api.Input.ArticleId", "Article Id is not valid");

    public static readonly Error UnexpectedError = new Error("Unexpected Validation state.", "Someting went wrong while validation");
}