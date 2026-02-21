using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public record CreateProjectInputModel(
        string Title, 
        string Description,
        int IdClient,
        int IdFreelancer,
        decimal TotalCost
    )
    {
        public Project ToEntity()
        {
            return new Project(Title, Description, IdClient, IdFreelancer, TotalCost);
        }
    }
}