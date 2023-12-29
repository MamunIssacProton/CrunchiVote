using CruchiVote.Service;
using CrunchiVote.Domain.Entities;
using CrunchiVote.Shared.DTOs;
using CrunchVote.Domain.Enums;

namespace CrunchiVote.Service.Interfaces;

 public interface IVoteService: IBaseService
{
     ValueTask<ResultDTO> AddVoteOnCommentAsync(Vote vote);

     ValueTask<List<VoteDTO>> GetVotesByCommentId(Guid commentId);
     
     ValueTask<ResultDTO> IsEligibleForVote(string username, Guid commentId,VoteType voteType);
     
}