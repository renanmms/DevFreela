using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;
        public CreateProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var projectModel = new ProjectViewModel(
                request.Id,
                request.Title,
                request.Description,
                request.IdClient,
                request.IdFreelancer,
                request.TotalCost
            );

            var project = new Project(projectModel.Id, projectModel.Title, projectModel.Description, projectModel.CreatedAt, projectModel.IdClient, projectModel.IdFreelancer, projectModel.TotalCost);

            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();

            return project.Id;  
        }
    }
}
