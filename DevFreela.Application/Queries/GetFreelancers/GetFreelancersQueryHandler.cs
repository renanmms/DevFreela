using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetFreelancers
{
    public class GetFreelancersQueryHandler : IRequestHandler<GetFreelancersQuery, ResultViewModel<List<User>>>
    {
        private readonly IUserRepository _repository;

        public GetFreelancersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<User>>> Handle(GetFreelancersQuery request, CancellationToken cancellationToken)
        {
            var freelancers = await _repository.GetFreelancersAsync();

            return ResultViewModel<List<User>>.Success(freelancers);
        }
    }
}
