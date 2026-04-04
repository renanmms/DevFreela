using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Queries.GetFreelancers
{
    public record GetFreelancersQuery() : IRequest<ResultViewModel<List<User>>>;
}

