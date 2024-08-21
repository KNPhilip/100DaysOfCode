using CleanBlog.Application.ArticleService.GetArticleByIdForEditing;
using CleanBlog.Application.Users;

namespace BlazingBlog.Application.Articles.GetArticleByIdForEditing;

public sealed class GetArticleByIdForEditingQueryHandler(IArticleRepository articleRepository, 
    IUserService userService) : IQueryHandler<GetArticleByIdForEditingQuery, ArticleResponseDto?>
{
    private readonly IArticleRepository _articleRepository = articleRepository;
    private readonly IUserService _userService = userService;

    public async Task<Result<ArticleResponseDto?>> Handle(GetArticleByIdForEditingQuery request, CancellationToken cancellationToken)
    {
        bool canEdit = await _userService.CurrentUserCanEditArticleAsync(request.Id);
        if (!canEdit)
        {
            return Result.Fail<ArticleResponseDto?>("You're not allowed to edit this article.");
        }

        Article? article = await _articleRepository.GetArticleByIdAsync(request.Id);
        var articleResponse = article.Adapt<ArticleResponseDto>();

        return articleResponse;
    }
}
