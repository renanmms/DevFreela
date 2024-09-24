using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.InsertComment
{
    public class InsertCommentCommandHandler : IRequestHandler<InsertCommentCommand, ResultViewModel>
    {
        private readonly DevFreelaDbContext _context;
        public InsertCommentCommandHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(InsertCommentCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == request.IdProject);
            if(project is null)
            {
                return ResultViewModel.Error("Projeto não encontrado.");
            }

            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);
            
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}