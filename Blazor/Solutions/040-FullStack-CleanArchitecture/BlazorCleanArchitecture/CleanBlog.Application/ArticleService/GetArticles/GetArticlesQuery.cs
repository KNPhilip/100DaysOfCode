using CleanBlog.Application.ArticleService.Dtos;
using MediatR;

namespace CleanBlog.Application.ArticleService.GetArticles;

public sealed class GetArticlesQuery 
    : IRequest<List<ArticleResponseDto>> { }
