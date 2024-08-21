using CleanBlog.Application.Users;

namespace CleanBlog.Application.ArticleService.UpdateArticle;

public sealed class UpdateArticleCommandHandler(
    IArticleRepository articleRepository, IUserService userService) :
    ICommandHandler<UpdateArticleCommand, ArticleResponseDto?>
{
    private readonly IArticleRepository _articleRepository = articleRepository;
    private readonly IUserService _userService = userService;

    public async Task<Result<ArticleResponseDto?>> Handle(
        UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        Article updatedArticle = request.Adapt<Article>();
        if (!await _userService.CurrentUserCanEditArticleAsync(updatedArticle.Id))
        {
            return Result.Fail<ArticleResponseDto?>("You're not allowed to edit this article! How did you get here?!");
        }

        Article? article = await _articleRepository
            .UpdateArticleAsync(updatedArticle);
        if (article is null)
        {
            return Result.Fail<ArticleResponseDto?>("Article does not exist."); ;
        }

        return article.Adapt<ArticleResponseDto>();
    }
}
