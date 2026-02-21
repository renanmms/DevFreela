using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.InsertUser
{
    public record InsertUserCommand(
        string FullName,
        string Email, 
        DateTime Birthdate,
        string Password,
        string Role
    ) : IRequest<ResultViewModel<int>>;
}