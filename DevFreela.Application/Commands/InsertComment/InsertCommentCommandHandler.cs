using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.InsertComment
{
    public class InsertCommentCommandHandler : IRequestHandler<InsertCommentCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;
        public InsertCommentCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(InsertCommentCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.ExistsAsync(request.IdProject);
            if(!exists)
            {
                return ResultViewModel.Error("Projeto não encontrado.");
            }

            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);
            
            await _repository.AddCommentAsync(comment);

            return ResultViewModel.Success();
        }
    }
}