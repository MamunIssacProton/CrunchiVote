namespace CruchiVote.Domain.ValueObjects;
public class UserId
{
    public Guid Value { get; private set; }

    private UserId(Guid value) => this.Value = value;

    public static UserId Create(Guid value) => new UserId(value);

    public static implicit operator Guid(UserId userId) => userId.Value;


}