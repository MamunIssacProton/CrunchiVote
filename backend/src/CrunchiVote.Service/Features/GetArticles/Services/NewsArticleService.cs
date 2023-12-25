using CruchiVote.Service.Features.GetArticles.Interface;
using CrunchiVote.Infrastructure.Features.GetArticles.Interfaces;
using CrunchiVote.Shared.DTOs;

namespace CruchiVote.Service.Features.GetArticles.Services;
internal class NewsArticleService : INewsArticleService
{
    readonly INewsArticleRepository NewsArticleRepository;
    public NewsArticleService(INewsArticleRepository newsArticleRepository) => this.NewsArticleRepository = newsArticleRepository;
    public async ValueTask<List<ArticleDTO>> GetArticlesAsync(int page = 1) => await this.NewsArticleRepository.GetArticlesAsync(page);

}