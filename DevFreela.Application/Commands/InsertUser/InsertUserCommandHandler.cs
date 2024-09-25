using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.InsertUser
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly DevFreelaDbContext _context;
        public InsertUserCommandHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                 var user = new User(request.FullName, request.Email, request.Birthdate);

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return ResultViewModel<int>.Success(user.Id);     
            }
            catch (Exception ex)
            {
                return ResultViewModel<int>.Error("Error while trying to create the user");
            }
        }
    }
}