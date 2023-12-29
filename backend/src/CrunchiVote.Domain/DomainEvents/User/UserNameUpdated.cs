using CrunchVote.Domain;

namespace CrunchiVote.Domain.DomainEvents.User;

public class UserNameAddeed: IDomainEvent
{
    public  required  string UserName { get; set; }
}