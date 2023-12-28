namespace CruchiVote.Domain.ValueObjects;

public record ArticleId
{
    public int Value { get; private set; }
    private ArticleId(int value) => this.Value = value;

    public static ArticleId Create(int value) => new ArticleId(value);

    public static implicit operator int(ArticleId articleId) => articleId.Value;

}