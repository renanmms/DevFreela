using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.InsertSkill
{
    public record InsertSkillCommandHandler : IRequestHandler<InsertSkillCommand, ResultViewModel<int>>
    {
        private readonly DevFreelaDbContext _context;
        public InsertSkillCommandHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var skill = new Skill(request.Description);

                _context.Skills.Add(skill);
                await _context.SaveChangesAsync();

                return ResultViewModel<int>.Success(skill.Id);
            }
            catch (Exception ex)
            {
                return ResultViewModel<int>.Error(ex.Message);
            }
            
        }
    }
}