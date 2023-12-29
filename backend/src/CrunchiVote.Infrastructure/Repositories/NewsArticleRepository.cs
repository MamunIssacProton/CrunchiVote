using System.Collections.Immutable;
using CrunchiVote.Infrastructure.ExtensionMethods;
using CrunchiVote.Infrastructure.Interfaces;
using CrunchiVote.Shared.DTOs;
using CrunchiVote.Shared.Models;
using CrunchiVote.Shared.Utils;
using Newtonsoft.Json;

namespace CrunchiVote.Infrastructure.Repositories;
internal sealed class NewsArticleRepository :INewsArticleRepository
{
    private readonly IHttpClientFactory ClientFactory;
    protected readonly ICommentsRepository CommentsRepository;

    public NewsArticleRepository(IHttpClientFactory clientFactory, ICommentsRepository commentsRepository)
    {
        this.ClientFactory = clientFactory;
        this.CommentsRepository = commentsRepository;
    }

    public async ValueTask<List<ArticleDTO>> GetArticlesAsync(int page = 1)
    {
        var endpoint = $"?page={page}&_embed=true&es=true&cachePrevention=0";
        var rawResponse = await this.ClientFactory.CreateClient(HttpClientsName.TechCrunch).GetStringAsync(endpoint);

        var articles = JsonConvert.DeserializeObject<List<NewsArticle>>(rawResponse);
        var res = new List<ArticleDTO>();
        foreach (var article in articles)
        {
           res.Add(new ArticleDTO(article.Id,article.Title.Rendered,article.Link,article.Yoast_Head.GetAuthorName(), await this.CommentsRepository.GetCommentsByArticleIdAsync(article.Id)));
            
        }
        return res;
    }


}