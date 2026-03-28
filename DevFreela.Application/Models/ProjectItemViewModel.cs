using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class ProjectItemViewModel
    {
        public ProjectItemViewModel(int id, string title, string clientName, string freelancerName, decimal totalCost, string description)
        {
            Id = id;
            Title = title;
            ClientName = clientName;
            FreelancerName = freelancerName;
            TotalCost = totalCost;
            Description = description;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string ClientName { get; private set; }
        public string FreelancerName { get; private set; }
        public decimal TotalCost { get; private set; }
        public string Description { get; set; }

        public static ProjectItemViewModel FromEntity(Project project)
        {
            return new(project.Id,
             project.Title,
             project.Client.FullName,
             project.Freelancer.FullName,
             project.TotalCost,
             project.Description);
        }
    }
}