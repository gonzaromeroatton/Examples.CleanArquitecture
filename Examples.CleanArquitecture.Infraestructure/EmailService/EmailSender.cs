using Examples.CleanArquitecture.Application.Contracts.Email;
using Examples.CleanArquitecture.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Examples.CleanArquitecture.Infraestructure.EmailService;

/// <summary>
/// 
/// </summary>
public sealed class EmailSender : IEmailSender
{
    /// <summary>
    /// 
    /// </summary>
    public EmailSettings _emailSettings { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="emailSettings"></param>
    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        this._emailSettings = emailSettings.Value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public async Task<bool> SendEmail(EmailMessage email)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);
        var to = new EmailAddress(email.To);
        var from = new EmailAddress
        {
            Email = _emailSettings.FromAddress,
            Name = _emailSettings.FromName
        };

        var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
        var response = await client.SendEmailAsync(message);

        return response.IsSuccessStatusCode;
    }
}
