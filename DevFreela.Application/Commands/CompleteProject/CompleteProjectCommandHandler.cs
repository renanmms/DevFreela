using System;
using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.CompleteProject
{
    public class CompleteProjectCommandHandler : IRequestHandler<CompleteProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;
        public CompleteProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<ResultViewModel> Handle(CompleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id);
            if(project is null)
            {
                return ResultViewModel.Error("Projeto não encontrado");
            }

            project.Complete();
            await _repository.UpdateAsync(project);

            return ResultViewModel.Success();
        }
    }
}