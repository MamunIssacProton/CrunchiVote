
using CrunchVote.Domain;
namespace CrunchiVote.Domain.DomainEvents.User;

public record UserIdCreated :IDomainEvent
{
    public  required  Guid UserId { get; set; }
}