using CrunchiVote.Shared.DTOs;
using System.Runtime.CompilerServices;
using CrunchiVote.Domain.Entities;
using CrunchiVote.Identity;

[assembly: InternalsVisibleTo("CrunchiVote.Service")]

namespace CrunchiVote.Infrastructure.Interfaces; 
internal interface ICommentsRepository : IBaseRepository
{
   internal ValueTask<ResultDTO> AddCommentOnArticleAsync(Comment comment);

   internal ValueTask<List<CommentDTO>> GetCommentsByArticleIdAsync(int articleId);
}