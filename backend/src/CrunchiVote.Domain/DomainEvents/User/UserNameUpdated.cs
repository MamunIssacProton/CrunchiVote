using CrunchVote.Domain;

namespace CrunchiVote.Domain.DomainEvents.User;

public class UserNameAdded: IDomainEvent
{
    public  required  string UserName { get; set; }
}