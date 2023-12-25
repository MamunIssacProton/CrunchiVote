using CrunchiVote.Shared.Models;

namespace CrunchiVote.Shared.Models;
public  class NewsArticle
{
    public int Id { get; set; }

    public string Link { get; set; }

    public TitleObject Title { get; set; }
    
    public string Yoast_Head { get; set; }

    public DateTime Modified { get; set; }
}