namespace CleanBlog.Presentation.Server.Components.Features.Articles;

public sealed class ArticleModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime DatePublished { get; set; } = DateTime.Now;
    public bool IsPublished { get; set; }
    public string? UserName { get; set; } = null;
}
