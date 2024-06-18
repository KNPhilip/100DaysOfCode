using System.Text.Json.Serialization;

namespace Domain.Models;

public sealed class User : DbEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? JobTitle { get; set; }
    public int? CompanyId { get; set; }
    public Company? Company { get; set; }
    [JsonIgnore]
    public List<JobPost>? HiringPosts { get; set; } = [];
}
