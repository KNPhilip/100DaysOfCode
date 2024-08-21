using CleanBlog.Application.ArticleService.Dtos;
using CleanBlog.Domain.Articles;
using Mapster;
using MediatR;

namespace CleanBlog.Application.ArticleService.GetArticleById;

public sealed class GetArticleByIdQueryHandler(
    IArticleRepository articleRepository) : 
    IRequestHandler<GetArticleByIdQuery, ArticleResponseDto?>
{
    public async Task<ArticleResponseDto?> Handle(
        GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        Article? result = await articleRepository
            .GetArticleByIdAsync(request.Id);
        if (result is null)
        {
            return null;
        }

        return result.Adapt<ArticleResponseDto>();
    }
}
