using CrunchiVote.Shared.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace CruchiVote.Service.Features.GetArticles.Interface;
interface INewsArticleService : IBaseService
{
    ValueTask<List<ArticleDTO>> GetArticlesAsync(int page = 1);
}