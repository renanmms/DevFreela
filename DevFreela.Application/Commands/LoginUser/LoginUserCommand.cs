using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.LoginUser;

public record LoginUserCommand(string Email, string Password) : IRequest<ResultViewModel<LoginViewModel>>;