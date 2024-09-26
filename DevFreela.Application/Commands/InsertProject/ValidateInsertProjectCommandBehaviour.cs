using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.InsertProject
{
    public class ValidateInsertProjectCommandBehaviour
        : IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>
    {
        private readonly DevFreelaDbContext _context;
        public ValidateInsertProjectCommandBehaviour(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var clientExists = _context.Users.Any(u => u.Id == request.IdClient);
            var freelancerExists = _context.Users.Any(u => u.Id == request.IdFreelancer);

            if(!clientExists || !freelancerExists)
            {
                return ResultViewModel<int>.Error("Invalid client or freelancer");
            }

            return await next();
        }
    }
}