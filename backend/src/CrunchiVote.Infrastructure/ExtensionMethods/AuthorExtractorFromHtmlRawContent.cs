using System.Text.RegularExpressions;

namespace CrunchiVote.Infrastructure.ExtensionMethods;

public static class AuthorExtractorFromHtmlRawContent
{
    public static string GetAuthorName(this string rawHtmlContent)
    {
        string pattern = @"<meta\s+name\s*=\s*""author""\s+content\s*=\s*""(.*?)""\s*/?>";

        Match match = Regex.Match(rawHtmlContent, pattern, RegexOptions.IgnoreCase);

        return !match.Success ? string.Empty : match.Groups[1].Value.Replace("&#039;", "'");
        
    }
}