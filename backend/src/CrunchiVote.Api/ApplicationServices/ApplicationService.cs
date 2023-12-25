using System.ComponentModel;
using CruchiVote.Service.Features.GetArticles.Interface;
using CrunchiVote.Api.Queries;
using CrunchiVote.Shared.DTOs;

namespace CrunchiVote.Api.ApplicationServices;

internal class ApplicationService
{
    private readonly INewsArticleService ArticleService;
    public ApplicationService(INewsArticleService articleService) => this.ArticleService = articleService;

    internal async ValueTask<List<ArticleDTO>> HandleQueryAsync(GetArticlesQuery query) => await  this.ArticleService.GetArticlesAsync(query.page);
}