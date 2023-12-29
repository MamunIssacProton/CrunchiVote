namespace CrunchVote.Domain.DomainEvents.Comment;

internal record CommentMessageUpdated:IDomainEvent
{
    internal  required  string Message { get; set; }
}