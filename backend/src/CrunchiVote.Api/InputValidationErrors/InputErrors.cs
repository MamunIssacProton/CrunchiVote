using CrunchVote.Domain;

namespace CrunchiVote.Api;

public static class InputErrors
{
    public static readonly Error InvalidPageNumber = new Error("Input.", "Page number is invalid");
}