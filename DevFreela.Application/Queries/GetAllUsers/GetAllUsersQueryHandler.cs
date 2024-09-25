using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<User>>>
    {
        private readonly DevFreelaDbContext _context;
        public GetAllUsersQueryHandler(DevFreelaDbContext context)
        {
            _context = context;    
        }

        public async Task<ResultViewModel<List<User>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _context.Users.ToListAsync();

                return ResultViewModel<List<User>>.Success(users);
            }
            catch (Exception)
            {
                return ResultViewModel<List<User>>.Error("Error while retrieving users from database");
            }
        }
    }
}