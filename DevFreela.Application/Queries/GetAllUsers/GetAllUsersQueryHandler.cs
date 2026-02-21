using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<User>>>
    {
        private readonly IUserRepository _repository;
        public GetAllUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<User>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _repository.GetAllAsync();

                return ResultViewModel<List<User>>.Success(users);
            }
            catch (Exception)
            {
                return ResultViewModel<List<User>>.Error("Error while retrieving users from database");
            }
        }
    }
}