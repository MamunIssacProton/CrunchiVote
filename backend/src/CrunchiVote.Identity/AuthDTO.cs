namespace CrunchiVote.Identity;

public record AuthDTO(bool isSuccess, string? message = default, string? authToken=default);
