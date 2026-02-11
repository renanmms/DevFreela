namespace DevFreela.Infrastructure.Notifications;

public class SendGridConfig
{
    public string FromEmail { get; set; } = string.Empty;
    public string FromName { get; set; } = string.Empty;
}