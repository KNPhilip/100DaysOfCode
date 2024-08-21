using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Domain.Dtos.Account
{
    public sealed class AccountRegistrationRequestDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required, EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;

        [Required, Compare("Password", ErrorMessage = "Passwords must match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
