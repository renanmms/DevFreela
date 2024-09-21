using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.StartProject
{
    public record StartProjectCommand(int Id) : IRequest<ResultViewModel>;
}