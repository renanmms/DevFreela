using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.CompleteProject
{
    public record CompleteProjectCommand(int Id) : IRequest<ResultViewModel>;
}