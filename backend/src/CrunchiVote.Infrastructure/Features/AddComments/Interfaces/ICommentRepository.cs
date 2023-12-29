using CrunchiVote.Shared.DTOs;
using System.Runtime.CompilerServices;
using CrunchiVote.Domain.Entities;
using CrunchiVote.Identity;

[assembly: InternalsVisibleTo("CrunchiVote.Service")]

namespace CrunchiVote.Infrastructure.Features.AddComments.Interfaces; 
interface ICommentsRepository : IBaseRepository
{
    ValueTask<ResultDTO> AddCommentOnArticleAsync(Comment comment);
}