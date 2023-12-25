using CrunchiVote.Infrastructure.Features.GetArticles.Interfaces;
using CrunchiVote.Shared.DTOs;

namespace CrunchiVote.Infrastructure.Features.GetArticles.Repositories;
internal class NewsArticleRepository : INewsArticleRepository
{
    public async ValueTask<List<ArticleDTO>> GetArticlesAsync(int page = 1)
    {
        await Task.Delay(10);
        return new List<ArticleDTO>();
    }
}