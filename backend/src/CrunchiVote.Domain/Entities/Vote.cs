using System.Diagnostics.CodeAnalysis;
using CrunchiVote.Domain.DomainEvents.User;
using CrunchVote.Domain;
using CrunchVote.Domain.DomainEvents.Comment;
using CrunchVote.Domain.DomainEvents.Vote;
using CrunchVote.Domain.Enums;

namespace CrunchiVote.Domain.Entities;
public class Vote : AggregateRoot
{
    internal  Guid Id { get; set; }
    
    internal  string GivenBy { get; set; }
    
    internal  Guid CommentId { get; set; }

    public  VoteType VoteType { get; set; }
    protected Vote(){}

    public Vote(Guid Id)
    {
        this.Id = Id;
        ApplyDomainEvent(new VoteIdCreated()
        {
            Id = Id
        });
    }

    public void AddVoteType(VoteType type)
    {
        this.VoteType = type;
    }
    public void AddUsername(string username) => ApplyDomainEvent(new UserNameAdded()
    {
        UserName = username
    });

    public void AddCommentId(Guid commentId) => ApplyDomainEvent(new CommentIdCreated()
    {
        Id = commentId
    });
    protected override void ChangeStateByUsingDomainEvent(IDomainEvent domainEvent)
    {
        switch (domainEvent)
        {
            case VoteIdCreated e:
                this.Id = e.Id;
                break;
             case  UserNameAdded e:
                 this.GivenBy = e.UserName;
                 break;
              case  CommentIdCreated e:
                  this.CommentId = e.Id;
                  break;
             default:
                 break;
        }
    }

    protected override void ValidateState()
    {
        if (this.Id == Guid.Empty)
            throw new Exception("invalid domain state");
    }
}