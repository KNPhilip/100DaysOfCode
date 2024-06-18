namespace Domain.Models;

public sealed class JobPost : DbEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string[]? Skills { get; set; } = [];
    public int? CompanyId { get; set; }
    public Company? Company { get; set; }
    public int? HiringManagerId { get; set; }
    public User? HiringManager { get; set; }
}
