using MediatR;

namespace CleanBlog.Application.ArticleService.DeleteArticle
{
    public sealed class DeleteArticleCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
