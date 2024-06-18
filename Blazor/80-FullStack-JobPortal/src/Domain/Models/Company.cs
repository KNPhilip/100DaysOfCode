namespace Domain.Models;

public sealed class Company : DbEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Industry { get; set; }
    public string? Location { get; set; }
    public int? EmployeeNumber { get; set; }
}
