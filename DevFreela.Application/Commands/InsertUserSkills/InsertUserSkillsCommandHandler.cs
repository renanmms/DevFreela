using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.InsertUserSkills
{
    public class InsertUserSkillsCommandHandler : IRequestHandler<InsertUserSkillsCommand, ResultViewModel>
    {
        private readonly ISkillRepository _repository;
        public InsertUserSkillsCommandHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(InsertUserSkillsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userSkills = request.SkillIds.Select(s => new UserSkill(request.Id, s)).ToList();
                await _repository.AddUserSkillAsync(userSkills);

                return ResultViewModel.Success();
            }
            catch (Exception ex)
            {
                return ResultViewModel.Error("Error while inserting user skills");
            }
        }
    }
}