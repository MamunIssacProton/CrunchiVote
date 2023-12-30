using CrunchVote.Domain;
using CrunchVote.Domain.Errors;

namespace CruchiVote.Domain.ValueObjects;
public record CommentMessage
{
    public string Value { get; private set; }

    private CommentMessage(string value) => this.Value = value;

    public static CommentMessage Create(string value)
    {
        return value.IsValid() ? new CommentMessage(value) :
            throw new DomainValidationError(
                StateValidationErrors.InvalidCommentMessage.Code,
                StateValidationErrors.InvalidCommentMessage.Description
            );
       
    }

    public static implicit operator string(CommentMessage commentMessage) => commentMessage.Value;

}