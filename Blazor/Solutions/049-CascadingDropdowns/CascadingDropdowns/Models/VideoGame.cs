namespace CascadingDropdowns.Models;

public sealed class VideoGame
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int PlatformId { get; set; }
    public int GenreId { get; set; }
}
