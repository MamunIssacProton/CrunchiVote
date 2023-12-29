using System.Runtime.CompilerServices;
using CrunchiVote.Identity;
using CrunchiVote.Shared.DTOs;
[assembly:InternalsVisibleTo("CruchiVote.Api")]
namespace CruchiVote.Service.Features.AddComments.Interfaces;

internal interface ICommentService: IBaseService
{
       ValueTask<ResultDTO> AddCommentOnArticleAsync(Comment comment);
}
