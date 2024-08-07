using DevFreela.API.Entities;

namespace DevFreela.API.Models
{
    public record UserViewModel(string FullName, string Email, DateTime BirthDate, List<string> Skills)
    {
        public static UserViewModel FromEntity(User user)
        {
            var skills = user.Skills.Select(s => s.Skill.Description).ToList();
            
            return new UserViewModel(user.FullName, user.Email, user.BirthDate, skills);
        }

    }
}