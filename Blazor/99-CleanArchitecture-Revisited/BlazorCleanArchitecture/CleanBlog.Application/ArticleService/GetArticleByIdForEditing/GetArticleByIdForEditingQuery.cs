namespace CleanBlog.Application.ArticleService.GetArticleByIdForEditing;

public sealed class GetArticleByIdForEditingQuery : IQuery<ArticleResponseDto?>
{
    public int Id { get; set; }
}
