using System.Text.RegularExpressions;
using CrunchVote.Domain.Enums;

namespace CrunchVote.Domain.Utls;

public static class Utils
{
    public static bool IsValid(this string input) => !string.IsNullOrEmpty(input);
    
    public static bool IsValidAsVoteId(this Guid input)
    {
        return input != Guid.Empty || Guid.TryParse(input.ToString(), out _);
    }
    public static bool IsValidAsArticleId(this int input)
    {
        return Regex.IsMatch(input: input.ToString(), pattern: @"^[1-9](?!000)\d{0,6}$");
      
    }
    public static bool IsValidAsCommentId(this Guid input)
    {
        return input != Guid.Empty || Guid.TryParse(input.ToString(), out _);
    }

    public static bool IsValidAsVoteType(this VoteType voteType)=> Enum.IsDefined(typeof(VoteType), voteType);

}