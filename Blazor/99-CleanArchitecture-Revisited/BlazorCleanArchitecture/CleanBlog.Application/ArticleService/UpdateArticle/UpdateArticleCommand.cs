namespace CleanBlog.Application.ArticleService.UpdateArticle;

public sealed class UpdateArticleCommand : ICommand<ArticleResponseDto?>
{
    private int id;

    public int Id 
    {
        get => id;
        set
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Id must be greater than 0");
            }

            id = value;
        }
    }

    public required string Title { get; set; }
    public string? Content { get; set; }
    public DateTime DatePublished { get; set; } = DateTime.Now;
    public bool IsPublished { get; set; }
}
