using EmailSenderSSR.Components.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace EmailSenderSSR.Extensions;

internal static class MailKitExtensions
{
    internal static void SetProperties(this MimeMessage email, EmailRequest emailRequest, IConfiguration configuration)
    {
        email.From.Add(MailboxAddress.Parse(configuration["Ethereal:Email"]));
        email.To.Add(MailboxAddress.Parse(emailRequest.To));
        email.Subject = emailRequest.Subject;
        email.Body = new TextPart(TextFormat.Html)
        {
            Text = emailRequest.Body
        };
    }

    internal static void SendEmail(this SmtpClient smtpClient, MimeMessage emailRequest, IConfiguration configuration)
    {
        smtpClient.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
        smtpClient.Authenticate(configuration["Ethereal:Email"], configuration["Ethereal:Password"]);
        smtpClient.Send(emailRequest);
        smtpClient.Disconnect(true);
    }
}
