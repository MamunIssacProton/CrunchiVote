namespace CrunchVote.Domain.DomainEvents.Vote;

public record VoteIdCreated : IDomainEvent
{
    public  Guid Id { get; set; }
}