using MediatR;

namespace DevFreela.Application.Notifications.ProjectCreated
{
    public record ProjectCreatedNotification(
        int Id, 
        string Title,
        decimal TotalCost) : INotification;
}