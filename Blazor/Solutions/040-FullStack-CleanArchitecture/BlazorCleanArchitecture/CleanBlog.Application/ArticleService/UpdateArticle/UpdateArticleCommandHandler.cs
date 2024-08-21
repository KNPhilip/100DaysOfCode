using CleanBlog.Application.ArticleService.Dtos;
using CleanBlog.Domain.Articles;
using Mapster;
using MediatR;

namespace CleanBlog.Application.ArticleService.UpdateArticle;

public sealed class UpdateArticleCommandHandler(
    IArticleRepository articleRepository) :
    IRequestHandler<UpdateArticleCommand, ArticleResponseDto?>
{
    public async Task<ArticleResponseDto?> Handle(
        UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        Article updatedArticle = request.Adapt<Article>();
        Article? article = await articleRepository
            .UpdateArticleAsync(updatedArticle);
        if (article is null)
        {
            return null;
        }

        return article.Adapt<ArticleResponseDto>();
    }
}
