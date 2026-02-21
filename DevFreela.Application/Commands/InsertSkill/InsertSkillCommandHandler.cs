using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.InsertSkill
{
    public record InsertSkillCommandHandler : IRequestHandler<InsertSkillCommand, ResultViewModel<int>>
    {
        private readonly ISkillRepository _repository;
        public InsertSkillCommandHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var skill = new Skill(request.Description);
                var id = await _repository.AddSkillAsync(skill);

                return ResultViewModel<int>.Success(id);
            }
            catch (Exception ex)
            {
                return ResultViewModel<int>.Error(ex.Message);
            }
            
        }
    }
}