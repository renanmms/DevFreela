using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;
        public DeleteProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }
    
        public async Task<ResultViewModel> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id);
            if(project is null)
            {
                return ResultViewModel.Error("Projeto não encontrado");
            }

            project.SetAsDeleted();
            await _repository.UpdateAsync(project);

            return ResultViewModel.Success();
        }
    }
}