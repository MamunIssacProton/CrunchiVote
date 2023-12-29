using CrunchiVote.Domain.Entities;
using CrunchiVote.Infrastructure.DbContexts;
using CrunchiVote.Infrastructure.Interfaces;
using CrunchiVote.Shared.DTOs;
using CrunchVote.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CrunchiVote.Infrastructure.Repositories;

internal class VoteRepository : IVoteRepository
{
    private readonly Context Context;

    public VoteRepository(Context context) => this.Context = context;
   
    public async ValueTask<ResultDTO> AddVoteOnCommentAsync(Vote vote)
    {
        var check = await this.IsEligibleForVote(vote.GivenBy, vote.CommentId, vote.VoteType);
        if (!check.isSuccess)
            return check;
        var givenVoteByUser = await this.Context.Votes.AsNoTracking()
            .SingleOrDefaultAsync(x => x.CommentId == vote.CommentId && x.GivenBy == vote.GivenBy);

        if (givenVoteByUser != null)
        {
            givenVoteByUser.VoteType = vote.VoteType;
            this.Context.Votes.Update(givenVoteByUser);
            await this.Context.SaveChangesAsync();
            return new ResultDTO(true, "Vote has been updated");
        }
        await this.Context.Votes.AddAsync(vote);
        await this.Context.SaveChangesAsync();
        return new ResultDTO(true, "Vote has been given");
       
    }

    public async ValueTask<List<VoteDTO>> GetVotesByCommentId(Guid commentId)
    {
        return await this.Context.Votes.AsNoTracking()
                                 .Where(x => x.CommentId == commentId)
                                 .Select(x=>new VoteDTO(x.CommentId,x.Id,x.GivenBy,x.VoteType)).ToListAsync();
    }

    public async ValueTask<ResultDTO> IsEligibleForVote(string username,Guid commentId, VoteType voteType)
    {
        var isOwnComment = await this.Context.Comments.AsNoTracking().AnyAsync(x=>x.UserName==username);
        if (isOwnComment)
        {
            return new ResultDTO(false, "You cannot vote your own comment!");
        }
        var isEligible=await  this.Context.Votes.AsNoTracking()
                                                    .AnyAsync
                                                    (
                                                        x =>x.CommentId==commentId && 
                                                                x.VoteType != voteType &&
                                                                x.GivenBy == username
                                                    );
   
            return isEligible? 
                new ResultDTO(true, $"{username} is eligible for the vote"):
                new ResultDTO(false, $"{username} is not eligible");

    }    
}