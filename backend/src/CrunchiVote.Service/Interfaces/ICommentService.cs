using System.Runtime.CompilerServices;
using CrunchiVote.Domain.Entities;
using CrunchiVote.Identity;
using CrunchiVote.Shared.DTOs;
[assembly:InternalsVisibleTo("CruchiVote.Api")]
namespace CruchiVote.Service.Interfaces;

internal interface ICommentService: IBaseService
{
     internal  ValueTask<ResultDTO> AddCommentOnArticleAsync(Comment comment);
}
