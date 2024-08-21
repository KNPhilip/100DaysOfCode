using CleanBlog.Application.ArticleService.Dtos;
using CleanBlog.Domain.Articles;
using Mapster;
using MediatR;

namespace CleanBlog.Application.ArticleService.CreateArticles;

public sealed class CreateArticleCommandHandler(
    IArticleRepository articleRepository) 
    : IRequestHandler<CreateArticleCommand, ArticleResponseDto>
{
    private readonly IArticleRepository _articleRespository = articleRepository;

    public async Task<ArticleResponseDto> Handle(
        CreateArticleCommand request, CancellationToken cancellationToken)
    {
        Article newArticle = request.Adapt<Article>();
        Article createdArticle = await _articleRespository.CreateArticleAsync(newArticle);
        return createdArticle.Adapt<ArticleResponseDto>();
    }
}
