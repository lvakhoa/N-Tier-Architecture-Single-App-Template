using EVOffice_BE.Modules.Email.Config;

namespace EVOffice_BE.Modules.Email.Services;

public interface IEmailService
{
    Task SendEmailAsync(EmailMessage emailMessage);
}
