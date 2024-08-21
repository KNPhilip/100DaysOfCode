using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Domain.Dtos.Login
{
    public sealed class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
