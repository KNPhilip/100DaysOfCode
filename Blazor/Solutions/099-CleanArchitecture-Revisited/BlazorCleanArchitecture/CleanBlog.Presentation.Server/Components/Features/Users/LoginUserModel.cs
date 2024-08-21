using System.ComponentModel.DataAnnotations;

namespace CleanBlog.Presentation.Server.Components.Features.Users;

public sealed class LoginUserModel
{
    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
