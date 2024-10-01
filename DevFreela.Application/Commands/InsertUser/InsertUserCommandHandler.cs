using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.InsertUser
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _repository;
        public InsertUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User(request.FullName, request.Email, request.Birthdate);

                await _repository.AddAsync(user);

                return ResultViewModel<int>.Success(user.Id);     
            }
            catch (Exception ex)
            {
                return ResultViewModel<int>.Error("Error while trying to create the user");
            }
        }
    }
}