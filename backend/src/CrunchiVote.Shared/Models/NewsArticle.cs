namespace CrunchVote.Shared.Models;
public sealed class NewsArticle
{
    public int Id { get; set; }

    public string Link { get; set; }

    public TitleObject TitleObject { get; set; }

}