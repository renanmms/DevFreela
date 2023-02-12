using DevFreela.Core.Enums;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, ProjectStatusEnum>
    {
        private readonly IProjectRepository _projectRepository;

        public DeleteProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectStatusEnum> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var status = await _projectRepository.DeleteProjectAsync(request.Id);
            return status;
        }
    }
}
