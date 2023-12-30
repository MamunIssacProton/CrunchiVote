using CrunchVote.Domain.Errors;
using CrunchVote.Domain.Utls;

namespace CruchiVote.Domain.ValueObjects;

public record ArticleId
{
    public int Value { get; private set; }
    private ArticleId(int value) => this.Value = value;

    public static ArticleId Create(int value)
    {
        return value.IsValidAsArticleId() ? new ArticleId(value) :
            throw new DomainValidationError(
                StateValidationErrors.InvalidArticleId.Code,
                StateValidationErrors.InvalidArticleId.Description
            );
    }

    public static implicit operator int(ArticleId articleId) => articleId.Value;

}