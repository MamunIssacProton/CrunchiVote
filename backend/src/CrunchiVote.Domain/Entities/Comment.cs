using System.Runtime.CompilerServices;
using CruchiVote.Domain.ValueObjects;
using CrunchiVote.Domain.DomainEvents.User;
using CrunchVote.Domain;
using CrunchVote.Domain.DomainEvents.Article;
using CrunchVote.Domain.DomainEvents.Comment;

[assembly:InternalsVisibleTo("CruchiVote.Service.Features.AddComments.Interfaces")]
[assembly:InternalsVisibleTo("CrunchiVote.Infrastructure")]
namespace CrunchiVote.Domain.Entities;

internal class Comment: AggregateRoot
{
    internal  required  ArticleId ArticleId { get; set; }
    internal required Guid Id { get; set; }
    
    internal required CommentMessage Message { get; set; }
    
    internal  required  string UserName { get; set; }

    public Comment()
    {
            
    }

    public Comment(Guid id) => ApplyDomainEvent(new CommentIdCreated()
    {
        Id = id
    });

    public void AddArticleId(int articleId) => ApplyDomainEvent(new ArticleIdAdded()
    {
        ArticleId = articleId
    });
    public void AddUserName(string username) => ApplyDomainEvent(new UserNameAddeed()
    {
        UserName = username
    });

    public void AddCommentMessage(string message) => ApplyDomainEvent(new CommentMessageUpdated()
    {
        Message = message
    });
    protected override void ChangeStateByUsingDomainEvent(IDomainEvent domainEvent)
    {
        switch (domainEvent)
        {
            
            case UserNameAddeed e:
                this.UserName = e.UserName;
                break;
            
            case  ArticleIdAdded e:
                
                this.ArticleId = ArticleId.Create(e.ArticleId);
            break;;
                
            case  CommentIdCreated e:
                this.Id = e.Id;
                break;
            
                case  CommentMessageUpdated e:
                    this.Message=CommentMessage.Create(e.Message);
                    break;
                default:
                    break;
                    
        }
    }

    protected override void ValidateState()
    {

        if (!this.Id.IsValid() && !this.UserName.IsValid())
        {
            throw new Exception("Invalidate state");
        }
    }
}