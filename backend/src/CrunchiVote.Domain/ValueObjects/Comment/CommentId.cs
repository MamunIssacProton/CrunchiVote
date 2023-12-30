using CrunchVote.Domain.Errors;
using CrunchVote.Domain.Utls;

namespace CruchiVote.Domain.ValueObjects;

public record CommandId
{
    public Guid Value { get; private set; }

    private CommandId(Guid value) => this.Value = value;

    public static CommandId Create(Guid value)
    {
        return value.IsValidAsCommentId() ? new CommandId(value) :
            throw new DomainValidationError(
                StateValidationErrors.InvalidCommentId.Code,
                StateValidationErrors.InvalidCommentId.Description
            );
    }

    public static implicit operator Guid(CommandId commandId) => commandId.Value;

}