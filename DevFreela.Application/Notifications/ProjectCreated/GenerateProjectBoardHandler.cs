using MediatR;

namespace DevFreela.Application.Notifications.ProjectCreated
{
    public class GenerateProjectBoardHandler : INotificationHandler<ProjectCreatedNotification>
    {
        public Task Handle(ProjectCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Project generated in board");

            return Task.CompletedTask;
        }
    }
}