namespace EbookLibrary.Models;

public sealed class Book
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Author { get; set; }
    public required string ImageUrl { get; set; }
    public required string SourceUrl { get; set; }
    public required decimal Price { get; set; }
}
