using CleanBlog.Domain.Articles;
using MediatR;

namespace CleanBlog.Application.ArticleService.DeleteArticle
{
    public sealed class DeleteArticleCommandHandler(IArticleRepository articleRepository)
        : IRequestHandler<DeleteArticleCommand, bool>
    {
        public async Task<bool> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            return await articleRepository.DeleteArticleAsync(request.Id);
        }
    }
}
