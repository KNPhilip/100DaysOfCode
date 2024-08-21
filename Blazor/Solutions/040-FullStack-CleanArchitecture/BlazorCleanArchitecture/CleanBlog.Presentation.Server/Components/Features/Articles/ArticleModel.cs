namespace CleanBlog.Presentation.Server.Components.Features.Articles;

public sealed class ArticleModel
{
    private int id;
    private string title = string.Empty;

    public int Id 
    {
        get => id;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Id must be greater than 0");
            }
            id = value;
        }
    }

    public string Title 
    {
        get => title;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            title = value;
        }
    }

    public string? Content { get; set; }
    public DateTime DatePublished { get; set; } = DateTime.Now;
    public bool IsPublished { get; set; }
}
