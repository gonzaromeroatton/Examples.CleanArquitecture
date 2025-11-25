using Examples.CleanArquitecture.Application.Models.Email;

namespace Examples.CleanArquitecture.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}
