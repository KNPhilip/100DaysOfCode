using CleanBlog.Application.ArticleService.Dtos;
using CleanBlog.Domain.Articles;
using Mapster;
using MediatR;

namespace CleanBlog.Application.ArticleService.GetArticles;

public sealed class GetArticlesQueryHandler(
    IArticleRepository articleRepository)
    : IRequestHandler<GetArticlesQuery, List<ArticleResponseDto>>
{
    public async Task<List<ArticleResponseDto>> Handle(
        GetArticlesQuery request, CancellationToken cancellationToken)
    {
        List<Article> articles = await articleRepository.GetAllArticlesAsync();
        return articles.Adapt<List<ArticleResponseDto>>();
    }
}
