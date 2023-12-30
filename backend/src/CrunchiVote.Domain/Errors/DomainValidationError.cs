namespace CrunchVote.Domain.Errors;

public class DomainValidationError: Exception
{
    public DomainValidationError(string code, string message)
    { 
    }
}