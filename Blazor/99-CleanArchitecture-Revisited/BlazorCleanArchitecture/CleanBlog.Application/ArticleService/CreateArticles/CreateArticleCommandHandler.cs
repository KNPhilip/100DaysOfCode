using CleanBlog.Application.Exceptions;
using CleanBlog.Application.Users;
using CleanBlog.Domain.Users;

namespace CleanBlog.Application.ArticleService.CreateArticles;

public sealed class CreateArticleCommandHandler(
    IArticleRepository articleRepository, IUserService userService) 
    : ICommandHandler<CreateArticleCommand, ArticleResponseDto>
{
    private readonly IArticleRepository _articleRepository = articleRepository;
    private readonly IUserService _userService = userService;

    public async Task<Result<ArticleResponseDto>> Handle(
        CreateArticleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newArticle = request.Adapt<Article>();
            newArticle.UserId = await _userService.GetCurrentUserIdAsync();
            if (!await _userService.CurrentUserCanCreateArticlesAsync())
            {
                return FailingResult();
            }

            Article article = await _articleRepository.CreateArticleAsync(newArticle);
            return article.Adapt<ArticleResponseDto>();
        }
        catch (UserNotAuthorizedException)
        {
            return FailingResult();
        }
    }

    private static Result<ArticleResponseDto> FailingResult()
    {
        return Result.Fail<ArticleResponseDto>("You're not allowed to create articles. Sorry! :/");
    }
}
