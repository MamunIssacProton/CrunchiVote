using CrunchiVote.Domain.Entities;
using CrunchiVote.Infrastructure.Interfaces;
using CrunchiVote.Service.Interfaces;
using CrunchiVote.Shared.DTOs;
using CrunchVote.Domain.Enums;

namespace CruchiVote.Service.Services;

public class VoteService : IVoteService
{
    private readonly IVoteRepository VoteRepository;

    public VoteService(IVoteRepository voteRepository) => this.VoteRepository = voteRepository;
 
    public async ValueTask<ResultDTO> AddVoteOnCommentAsync(Vote vote)
    {
        return await this.VoteRepository.AddVoteOnCommentAsync(vote);
    }

    public async ValueTask<List<VoteDTO>> GetVotesByCommentId(Guid commentId)
    {
        return await this.VoteRepository.GetVotesByCommentId(commentId);
    }

    public async ValueTask<ResultDTO> IsEligibleForVote(string username,Guid commentId, VoteType voteType)
    {
        return await this.VoteRepository.IsEligibleForVote(username,commentId, voteType);
    }
}