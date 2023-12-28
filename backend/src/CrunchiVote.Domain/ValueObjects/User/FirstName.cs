namespace CruchiVote.Domain.ValueObjects;

public record FirstName
{
    public  string Value { get; private set; }

    private FirstName(string value) => this.Value=value;

    public static FirstName Create(string value) => new FirstName(value);

    public static implicit operator string(FirstName firstName) => firstName.Value;
}