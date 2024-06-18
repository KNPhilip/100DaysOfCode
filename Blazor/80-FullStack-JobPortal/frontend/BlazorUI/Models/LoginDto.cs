using System.ComponentModel.DataAnnotations;

namespace BlazorUI.Models;

public sealed class LoginDto
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
