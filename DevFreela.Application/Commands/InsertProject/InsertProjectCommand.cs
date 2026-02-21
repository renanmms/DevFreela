using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.InsertProject
{
    public record InsertProjectCommand(
        string Title, 
        string Description,
        int IdClient,
        int IdFreelancer,
        decimal TotalCost
    ) : IRequest<ResultViewModel<int>>;
}