using CleanBlog.Domain.Abstractions;

namespace CleanBlog.Domain.Articles;

public sealed class Article : DbEntity
{
    private string title = string.Empty;

    public required string Title 
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
