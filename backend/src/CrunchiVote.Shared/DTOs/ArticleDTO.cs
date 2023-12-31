namespace CrunchiVote.Shared.DTOs;

public record ArticleDTO(int Id, string heading, string link, string author, List<CommentDTO?> comments=default);

public static class Artcls
{
    public static List<ArticleDTO> Empty = new List<ArticleDTO>();
}
