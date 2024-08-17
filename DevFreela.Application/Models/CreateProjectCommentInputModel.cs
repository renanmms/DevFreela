namespace DevFreela.Application.Models
{
    public record CreateProjectCommentInputModel(
        string Content,
        int IdProject,
        int IdUser);
}
