using System.Runtime.CompilerServices;
using CrunchiVote.Shared.DTOs;

[assembly:InternalsVisibleTo("CrunchiVote.Api")]
namespace CruchiVote.Service.Features.GetArticles.Interface;
internal interface INewsArticleService : IBaseService
{
    ValueTask<List<ArticleDTO>> GetArticlesAsync(int page = 1);
}