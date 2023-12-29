using CrunchVote.Domain.Enums;

namespace CrunchiVote.Shared.DTOs;

public record VoteDTO(Guid commentId, Guid voteId, string givenBy, VoteType VoteType);
