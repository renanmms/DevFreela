namespace DevFreela.API.Models
{
    public record CreateProjectCommentInputModel(
        string Content,
        int IdProject,
        int IdUser);
}
