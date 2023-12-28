using System.Runtime.CompilerServices;
using CruchiVote.Domain.ValueObjects;
using CrunchiVote.Domain.DomainEvents.User;
using CrunchVote.Domain;
[assembly:InternalsVisibleTo("CrunchiVote.Infrastructure")]
namespace CrunchiVote.Domain.Entities;

internal sealed class User : AggregateRoot
{
    public required  string UserName { get; set; }
    
    public required FirstName FirstName { get;  set; }
    
    public required LastName LastName { get;  set; }

    public User()
    {
            
    }

    public User(string userName)
    {
        this.UserName = userName;
    }

    public void AddUsername(string username)
    {
       
    }
    public void AddFirstName(string firstName)
    {
        ApplyDomainEvent(new FirstNameUpdated()

        {
            FirstName = firstName
        });
    }

    public void AddLastName(string lastName) => ApplyDomainEvent(new LastNameUpdated()
    {
        LastName = lastName
    });
    

    protected override void ChangeStateByUsingDomainEvent(IDomainEvent domainEvent)
    {
        switch (domainEvent)
        {
            case UserIdCreated e:
                //this.userName=UserName.Create(e.);
                
                break;
            case  UserNameUpdated e:
              
                break;
            
            case  FirstNameUpdated e:
                this.FirstName = FirstName.Create(e.FirstName);
                break;
            
            case  LastNameUpdated e:
                this.LastName= LastName.Create(e.LastName);
                break;
        }
    }

    protected override void ValidateState()
    {

//this.userId!=null&& this.userId.IsValid() &&
        var isValid = 
                      
                      this.UserName!=null && this.UserName.IsValid() &&
                      this.FirstName!=null && this.FirstName.Value.IsValid() &&
                      this.LastName!=null && this.LastName.Value.IsValid();
   
    }
}