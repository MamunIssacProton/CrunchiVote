using CrunchVote.Shared.DTOs;

namespace CruchiVote.Service.Interface;
interface INewsArticleService
{
    ValueTask<ArticleDTO> GetArticlesAsync(int page = 1);
}