using CrunchVote.Domain;

namespace CrunchiVote.Domain.DomainEvents.User;

public class UserNameUpdated: IDomainEvent
{
    public  required  string UserName { get; set; }
}