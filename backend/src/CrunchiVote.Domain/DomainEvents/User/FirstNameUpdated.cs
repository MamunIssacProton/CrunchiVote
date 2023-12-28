using CrunchVote.Domain;

namespace CrunchiVote.Domain.DomainEvents.User;

public class FirstNameUpdated : IDomainEvent
{
    public  required  string FirstName { get; set; }
}