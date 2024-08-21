namespace CleanBlog.Application.ArticleService.DeleteArticle
{
    public sealed class DeleteArticleCommand : ICommand
    {
        public int Id { get; set; }
    }
}
