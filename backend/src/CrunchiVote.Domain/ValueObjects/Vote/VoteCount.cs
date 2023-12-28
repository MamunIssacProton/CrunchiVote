namespace CruchiVote.Domain.ValueObjects;
public record VoteCount
{
    public int Value { get; private set; }

    private VoteCount(int value) => this.Value = value;

    public static VoteCount Create(int value) => new VoteCount(value);

    public static implicit operator int(VoteCount voteCount) => voteCount.Value;

}