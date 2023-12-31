namespace CrunchiVote.Api;

internal class Literal
{
    internal const string RateLimitFixedByClientIp = nameof(RateLimitFixedByClientIp);
}

internal record ApiEndpoints
{
    internal const string Articles = nameof(Articles);
    internal const string RegisterUser = nameof(RegisterUser);
    internal const string LoginUser = nameof(LoginUser);
    internal const string PostComment = nameof(PostComment);
    internal const string GetCommentsById = nameof(GetCommentsById);
    internal const string GetVotesByCommentId = nameof(GetVotesByCommentId);
    internal const string AddVoteOnComment = nameof(AddVoteOnComment);
    

}
internal class Fallbacks
{
    internal const string ArticleFallBack = nameof(ArticleFallBack);
}

internal class ConfigSection
{
    internal const string TechCrunchClientOptions = nameof(TechCrunchClientOptions);
}
