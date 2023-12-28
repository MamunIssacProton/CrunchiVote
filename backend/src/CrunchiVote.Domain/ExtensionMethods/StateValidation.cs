namespace CrunchVote.Domain;

public static class StateValidation
{
    public static bool IsValid(this string value) => !string.IsNullOrEmpty(value);

    public static bool IsValid(this Guid value) => Guid.Empty!=value;
}