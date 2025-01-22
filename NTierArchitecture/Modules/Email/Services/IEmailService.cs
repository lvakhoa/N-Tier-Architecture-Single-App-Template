using NTierArchitecture.Modules.Email.Config;

namespace NTierArchitecture.Modules.Email.Services;

public interface IEmailService
{
    Task SendEmailAsync(EmailMessage emailMessage);
}
