namespace BlazorUI.Models;

public sealed class JobPostDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string[]? Skills { get; set; } = [];
    public int? CompanyId { get; set; }
    public CompanyDto? Company { get; set; }
    public int? HiringManagerId { get; set; }
    public UserDto? HiringManager { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsSoftDeleted { get; set; }
}
