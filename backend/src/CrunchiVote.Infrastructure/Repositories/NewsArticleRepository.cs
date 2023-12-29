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

    public NewsArticleRepository(IHttpClientFactory clientFactory)
    {
        this.ClientFactory = clientFactory;
        this.CommentsRepository = CommentsRepository;
    }

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