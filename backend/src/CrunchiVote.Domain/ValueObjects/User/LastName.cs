namespace CruchiVote.Domain.ValueObjects;

public record LastName
{
    public  string Value { get; private set; }

    private LastName(string value) => this.Value = value;

    public static LastName Create(string value) => new LastName(value);

    public static implicit operator string(LastName lastName) => lastName.Value;
    
}