using DevFreela.Application.Models;
using DevFreela.Application.Notifications.ProjectCreated;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.InsertProject
{
    public class InsertProjectCommandHandler : IRequestHandler<InsertProjectCommand, ResultViewModel<int>>
    {
        private readonly DevFreelaDbContext _context;
        private readonly IMediator _mediator;
        public InsertProjectCommandHandler(DevFreelaDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        
        public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Title,
                request.Description,
                request.IdClient,
                request.IdFreelancer,
                request.TotalCost);

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            var notification = new ProjectCreatedNotification(project.Id, project.Title, project.TotalCost);
            await _mediator.Publish(notification);

            return ResultViewModel<int>.Success(project.Id);
        }
    }
}