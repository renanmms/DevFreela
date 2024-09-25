using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Queries.GetAllUsers
{
    public record GetAllUsersQuery() : IRequest<ResultViewModel<List<User>>>;
}