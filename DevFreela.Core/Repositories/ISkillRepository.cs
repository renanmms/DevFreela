using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<int> AddSkillAsync(Skill skill);
        Task AddUserSkillAsync(List<UserSkill> userSkills);
    }
}