using System.Text.Json.Serialization;

namespace FullStack.Shared.Entities;

public sealed class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    [JsonIgnore]
    public List<VideoGame> VideoGames { get; set; } = [];
}
