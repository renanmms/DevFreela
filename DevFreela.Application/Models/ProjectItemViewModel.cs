using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public record ProjectItemViewModel(int Id,
            int IdClient,
            string Title,
            string ClientName,
            string FreelancerName,
            decimal TotalCost,
            string Description)
    {
        public static ProjectItemViewModel FromEntity(Project project)
        {
            return new(project.Id,
             project.IdClient,
             project.Title,
             project.Client.FullName,
             project.Freelancer.FullName,
             project.TotalCost,
             project.Description);
        }
    }
}