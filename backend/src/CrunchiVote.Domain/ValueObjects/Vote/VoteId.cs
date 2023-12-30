using CrunchVote.Domain.Errors;
using CrunchVote.Domain.Utls;

namespace CruchiVote.Domain.ValueObjects;

public record VoteId
{
    public Guid Value { get; private set; }

    private VoteId(Guid value) => this.Value = value;

    public static VoteId Create(Guid value)
    {
        return value.IsValidAsVoteId() ? new VoteId(value) :
            throw new DomainValidationError(
                StateValidationErrors.InvalidVoteId.Code,
                StateValidationErrors.InvalidVoteId.Description
            );
    }

    public static implicit operator Guid(VoteId voteId) => voteId.Value;

}