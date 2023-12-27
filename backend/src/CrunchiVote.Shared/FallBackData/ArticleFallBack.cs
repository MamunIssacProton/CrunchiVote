using CrunchiVote.Shared.DTOs;

namespace CrunchVote.Shared.FallBackData;

public  record ArticleFallBack
{
    public static List<ArticleDTO> Empty => new List<ArticleDTO>(){new ArticleDTO(0,string.Empty,string.Empty,string.Empty)};
}