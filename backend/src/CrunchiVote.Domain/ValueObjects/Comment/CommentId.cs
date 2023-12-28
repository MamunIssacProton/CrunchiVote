namespace CruchiVote.Domain.ValueObjects;

public record CommandId
{
    public Guid Value { get; private set; }

    private CommandId(Guid value) => this.Value = value;

    public static CommandId Create(Guid value) => new CommandId(value);

    public static implicit operator Guid(CommandId commandId) => commandId.Value;

}