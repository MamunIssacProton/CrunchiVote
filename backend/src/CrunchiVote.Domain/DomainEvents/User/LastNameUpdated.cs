using CrunchVote.Domain;

namespace CrunchiVote.Domain.DomainEvents.User;

public class LastNameUpdated : IDomainEvent
{
    public  required  string LastName { get; set; }
}