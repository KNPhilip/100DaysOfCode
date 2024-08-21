using CleanBlog.Application.Users;

namespace CleanBlog.Application.ArticleService.DeleteArticle
{
    public sealed class DeleteArticleCommandHandler(IArticleRepository articleRepository,
        IUserService userService) : ICommandHandler<DeleteArticleCommand>
    {
        private readonly IArticleRepository _articleRepository = articleRepository;
        private readonly IUserService _userService = userService;

        public async Task<Result> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            if (!await _userService.CurrentUserCanEditArticleAsync(request.Id))
            {
                return Result.Fail<ArticleResponseDto?>("You're not allowed to delete this article! How did you get here?!");
            }

            bool deleted = await _articleRepository.DeleteArticleAsync(request.Id);
            if (deleted)
            {
                return Result.Ok();
            }

            return Result.Fail("The article does not exist.");
        }
    }
}
