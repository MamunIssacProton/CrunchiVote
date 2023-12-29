namespace CrunchVote.Domain.DomainEvents.Comment;

internal record CommentIdCreated : IDomainEvent
{
    internal  Guid Id { get; set; }
    
}