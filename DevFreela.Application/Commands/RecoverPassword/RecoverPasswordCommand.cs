using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.RecoverPassword;

public record RecoverPasswordCommand(string Email) : IRequest<ResultViewModel>;