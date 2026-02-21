namespace DevFreela.Application.Models
{
    public record UpdateProjectInputModel(
        int IdProject, 
        string Title,
        string Description, 
        decimal TotalCost);
}
