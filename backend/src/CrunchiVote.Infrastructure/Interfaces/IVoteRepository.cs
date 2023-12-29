using CrunchiVote.Domain.Entities;
using CrunchiVote.Shared.DTOs;
using CrunchVote.Domain.Enums;

namespace CrunchiVote.Infrastructure.Interfaces;

public interface IVoteRepository: IBaseRepository
{
    ValueTask<ResultDTO> AddVoteOnCommentAsync(Vote vote);

    ValueTask<List<VoteDTO>> GetVotesByCommentId(Guid commentId);

    ValueTask<ResultDTO> IsEligibleForVote(string username, Guid commentId,VoteType voteType);
}