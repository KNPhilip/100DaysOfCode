using CleanBlog.Application.Users;
using CleanBlog.Domain.Users;

namespace CleanBlog.Application.ArticleService.GetArticleById;

public sealed class GetArticleByIdQueryHandler(
    IArticleRepository articleRepository, IUserRepository userRepository,
    IUserService userService) : IQueryHandler<GetArticleByIdQuery, ArticleResponseDto?>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUserService _userService = userService;

    public async Task<Result<ArticleResponseDto?>> Handle(
        GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        Article? article = await articleRepository
            .GetArticleByIdAsync(request.Id);

        if (article is null)
        {
            return Result.Fail<ArticleResponseDto?>("The article does not exist.");
        }

        var articleResponse = article.Adapt<ArticleResponseDto>();
        if (article.UserId is not null)
        {
            IUser? author = await _userRepository.GetUserByIdAsync(article.UserId);
            articleResponse.UserName = author?.UserName ?? "Unknown";
            articleResponse.UserId = article.UserId;
            articleResponse.CanEdit = await _userService
                .CurrentUserCanEditArticleAsync(article.Id);
        }
        else
        {
            articleResponse.UserName = "Unknown";
        }

        return articleResponse;
    }
}
