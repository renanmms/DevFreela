using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DevFreela.Infrastructure.Notifications;

public interface IEmailService
{
    Task SendAsync(string email, string subject, string message);
}

public class EmailService : IEmailService
{
    private readonly ISendGridClient _client;
    private readonly SendGridConfig _sendGridConfig;
    
    public EmailService(ISendGridClient client, IOptions<SendGridConfig> options)
    {
        _client = client;
        _sendGridConfig = options.Value;
    }
    
    public async Task SendAsync(string email, string subject, string message)
    {
        var sendGridMessage = new SendGridMessage
        {
            From = new EmailAddress(_sendGridConfig.FromEmail, _sendGridConfig.FromName),
            Subject = subject
        };
        
        sendGridMessage.AddContent(MimeType.Text, message);
        sendGridMessage.AddTo(new EmailAddress(email));

        var response = await _client.SendEmailAsync(sendGridMessage);
    }
}