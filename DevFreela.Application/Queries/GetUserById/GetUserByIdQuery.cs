using MediatR;
using DevFreela.Application.Models;

namespace DevFreela.Application.Queries.GetUserById
{
    public record GetUserByIdQuery(int Id) : IRequest<ResultViewModel<UserViewModel>>;
}