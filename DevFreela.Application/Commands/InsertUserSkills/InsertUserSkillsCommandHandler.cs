using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.InsertUserSkills
{
    public class InsertUserSkillsCommandHandler : IRequestHandler<InsertUserSkillsCommand, ResultViewModel>
    {
        private readonly DevFreelaDbContext _context;
        public InsertUserSkillsCommandHandler(DevFreelaDbContext context)
        {
            _context = context;    
        }

        public async Task<ResultViewModel> Handle(InsertUserSkillsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userSkills = request.SkillIds.Select(s => new UserSkill(request.Id, s)).ToList();

                _context.UserSkills.AddRange(userSkills);
                await _context.SaveChangesAsync();

                return ResultViewModel.Success();
            }
            catch (Exception ex)
            {
                return ResultViewModel.Error("Error while inserting user skills");
            }
        }
    }
}