using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.RecoverPassword;

public record RequestPasswordRecoveryCommand(string Email) : IRequest<ResultViewModel>;