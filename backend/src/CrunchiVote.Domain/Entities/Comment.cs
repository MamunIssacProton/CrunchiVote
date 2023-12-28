using CruchiVote.Domain.ValueObjects;
using CrunchVote.Domain;

namespace CrunchiVote.Domain.Entities;

internal class Comment: AggregateRoot
{
    internal required Guid Id { get; set; }
    
    internal required CommentMessage Message { get; set; }
    
    internal  required  User CommentedBy { get; set; }
    protected override void ChangeStateByUsingDomainEvent(IDomainEvent domainEvent)
    {
        throw new NotImplementedException();
    }

    protected override void ValidateState()
    {
        throw new NotImplementedException();
    }
}