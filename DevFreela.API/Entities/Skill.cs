namespace DevFreela.API.Entities
{
    public class Skill : BaseEntity
    {
        public Skill(string description)
        {
            Description = description;
        }
        
        public string Description { get; private set; }
        public List<UserSkill> UserSkills { get; set; }
    }
}