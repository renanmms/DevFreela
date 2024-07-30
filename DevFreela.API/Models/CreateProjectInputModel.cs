namespace DevFreela.API.Models
{
    public record CreateProjectInputModel(
        string Title, 
        string Description,
        int IdClient,
        int IdFreelancer,
        decimal TotalCost
    );
}
