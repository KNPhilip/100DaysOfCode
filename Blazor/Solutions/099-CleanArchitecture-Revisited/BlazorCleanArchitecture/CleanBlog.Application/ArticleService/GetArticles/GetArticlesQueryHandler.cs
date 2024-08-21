using CleanBlog.Application.Users;
using CleanBlog.Domain.Users;

namespace CleanBlog.Application.ArticleService.GetArticles;

public sealed class GetArticlesQueryHandler(
    IArticleRepository articleRepository, IUserRepository userRepository,
    IUserService userService) : IQueryHandler<GetArticlesQuery, List<ArticleResponseDto>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUserService _userService = userService;

    public async Task<Result<List<ArticleResponseDto>>> Handle(
        GetArticlesQuery request, CancellationToken cancellationToken)
    {
        List<Article> articles = await articleRepository.GetAllArticlesAsync();
        List<ArticleResponseDto> response = [];

        foreach (Article article in articles)
        {
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
            response.Add(articleResponse);
        }

        return response.OrderByDescending(a => a.DatePublished).ToList();
    }
}
