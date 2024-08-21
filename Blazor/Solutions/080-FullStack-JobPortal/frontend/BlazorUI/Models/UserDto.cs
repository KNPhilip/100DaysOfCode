namespace BlazorUI.Models;

public sealed class UserDto
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? JobTitle { get; set; }
    public int? CompanyId { get; set; }
    public CompanyDto? Company { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsSoftDeleted { get; set; }
    public string FullName { get => FirstName + " " + LastName; }

}
