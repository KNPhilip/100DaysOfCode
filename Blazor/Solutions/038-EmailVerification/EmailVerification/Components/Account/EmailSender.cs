using EmailVerification.Data;
using EmailVerification.Dtos;
using Mandrill;
using Mandrill.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace EmailVerification.Components.Account;

public sealed class EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
    ILogger<EmailSender> logger) : IEmailSender<ApplicationUser>
{
    private readonly ILogger logger = logger;

    public AuthMessageSenderOptions Options { get; } = optionsAccessor.Value;

    public Task SendConfirmationLinkAsync(ApplicationUser user, string email,
        string confirmationLink) => SendEmailAsync(email, "Confirm your email",
        $"Please confirm your account by " +
        "<a href='{confirmationLink}'>clicking here</a>.");

    public Task SendPasswordResetLinkAsync(ApplicationUser user, string email,
        string resetLink) => SendEmailAsync(email, "Reset your password",
        $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");

    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email,
        string resetCode) => SendEmailAsync(email, "Reset your password",
        $"Please reset your password using the following code: {resetCode}");

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(Options.EmailAuthKey))
        {
            throw new Exception("Null EmailAuthKey");
        }

        await Execute(Options.EmailAuthKey, subject, message, toEmail);
    }

    public async Task Execute(string apiKey, string subject, string message,
        string toEmail)
    {
        MandrillApi api = new(apiKey);
        MandrillMessage mandrillMessage = new("sarah@contoso.com", toEmail,
            subject, message);
        await api.Messages.SendAsync(mandrillMessage);

        logger.LogInformation("Email to {EmailAddress} sent!", toEmail);
    }
}
