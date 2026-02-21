using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;
using MediatR;

namespace DevFreela.Application.Commands.InsertUser
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;
        public InsertUserCommandHandler(
            IUserRepository repository,
            IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var hash = _authService.ComputeHash(request.Password);
                var user = new User(request.FullName, request.Email, request.Birthdate, hash, request.Role);
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