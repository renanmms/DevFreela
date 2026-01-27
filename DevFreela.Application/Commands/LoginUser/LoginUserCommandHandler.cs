using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;
using MediatR;

namespace DevFreela.Application.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResultViewModel<LoginViewModel>>
{
    private readonly IUserRepository _repository;
    private readonly IAuthService _authService;

    public LoginUserCommandHandler(
        IUserRepository repository,
        IAuthService authService)
    {
        _repository = repository;
        _authService = authService;
    }
    
    public async Task<ResultViewModel<LoginViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var hash = _authService.ComputeHash(request.Password);
        var user = await _repository.GetByEmailAndPasswordAsync(request.Email, hash);

        if (user is null)
            return ResultViewModel<LoginViewModel>.Error("User not found!");

        var token = _authService.GenerateToken(user.Email, user.Role);
        
        return ResultViewModel<LoginViewModel>.Success(new LoginViewModel(token));
    }
}