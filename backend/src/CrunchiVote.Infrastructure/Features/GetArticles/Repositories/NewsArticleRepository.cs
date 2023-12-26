using System.Collections.Immutable;
using CrunchiVote.Infrastructure.ExtensionMethods;
using CrunchiVote.Infrastructure.Features.GetArticles.Interfaces;

using CrunchiVote.Shared.DTOs;
using CrunchiVote.Shared.Models;
using CrunchiVote.Shared.Utils;
using Newtonsoft.Json;

namespace CrunchiVote.Infrastructure.Features.GetArticles.Repositories;
internal sealed class NewsArticleRepository :INewsArticleRepository
{
    private readonly IHttpClientFactory ClientFactory;
    public NewsArticleRepository(IHttpClientFactory clientFactory) => this.ClientFactory = clientFactory;
    public async ValueTask<List<ArticleDTO>> GetArticlesAsync(int page = 1)
    {
        
        var endpoint = $"?page={page}&_embed=true&es=true&cachePrevention=0";
        var rawResponse=await  this.ClientFactory.CreateClient(HttpClientsName.TechCrunch).GetStringAsync(endpoint);

           return JsonConvert.DeserializeObject<List<NewsArticle>>(rawResponse).
                                    Select(article=>
                                            new ArticleDTO(article.Id,article.Title.Rendered,
                                                           article.Link,article.Yoast_Head.GetAuthorName())
                                            
                                            )
                                    .ToList();

    }
}