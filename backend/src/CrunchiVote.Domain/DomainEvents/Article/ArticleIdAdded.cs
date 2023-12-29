namespace CrunchVote.Domain.DomainEvents.Article;

internal record ArticleIdAdded : IDomainEvent
{
    internal  required  int ArticleId { get; set; }
}