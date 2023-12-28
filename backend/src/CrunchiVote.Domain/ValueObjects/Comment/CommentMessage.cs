namespace CruchiVote.Domain.ValueObjects;
public record CommentMessage
{
    public string Value { get; private set; }

    private CommentMessage(string value) => this.Value = value;

    public static CommentMessage Create(string value) => new CommentMessage(value);

    public static implicit operator string(CommentMessage commentMessage) => commentMessage.Value;

}