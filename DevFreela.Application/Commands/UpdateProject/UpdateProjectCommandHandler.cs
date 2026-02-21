using System;
using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;
        public UpdateProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.IdProject);
            if(project is null)
            {
                return ResultViewModel.Error("Projeto não encontrado");
            }
            
            project.Update(request.Title, request.Description, request.TotalCost);
            await _repository.UpdateAsync(project);

            return ResultViewModel.Success();
        }
    }
}