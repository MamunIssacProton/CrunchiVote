namespace CruchiVote.Domain.ValueObjects;

public class VoteId
{
    public Guid Value { get; private set; }

    private VoteId(Guid value) => this.Value = value;

    public static VoteId Create(Guid value) => new VoteId(value);

    public static implicit operator Guid(VoteId voteId) => voteId.Value;

}