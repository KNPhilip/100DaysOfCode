using System.ComponentModel.DataAnnotations;

namespace BlazorUI.Models;

public sealed class RegisterDto
{
    [Required, MinLength(2), MaxLength(30)]
    public string FirstName { get; set; } = string.Empty;
    [Required, MinLength(2), MaxLength(40)]
    public string LastName { get; set; } = string.Empty;
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required, MinLength(6), MaxLength(20)]
    public string Password { get; set; } = string.Empty;
}
