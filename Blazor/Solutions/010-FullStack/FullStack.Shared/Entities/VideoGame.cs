namespace FullStack.Shared.Entities;

public sealed class VideoGame
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int? ReleaseYear { get; set; }
    public Publisher? Publisher { get; set; }
    public int PublisherId { get; set; }
}
