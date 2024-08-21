namespace BlazorUI.Models;

public sealed class CompanyDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Industry { get; set; }
    public string? Location { get; set; }
    public int? EmployeeNumber { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsSoftDeleted { get; set; }
}
