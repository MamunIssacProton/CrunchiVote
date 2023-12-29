using CrunchiVote.Shared.DTOs;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("CrunchiVote.Service")]

namespace CrunchiVote.Infrastructure.Interfaces;
internal interface INewsArticleRepository : IBaseRepository
{
    ValueTask<List<ArticleDTO>> GetArticlesAsync(int page = 1);
}