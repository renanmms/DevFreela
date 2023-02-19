using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<ProjectDTO>> GetAllAsync();
        Task<ProjectDTO> GetByIdAsync(int id);
        Task<int> CreateProjectAsync(Project project);
        Task<ProjectStatusEnum> DeleteProjectAsync(int id);
        Task<ProjectStatusEnum> FinishProjectAsync(int id);
        Task<ProjectStatusEnum> StartProjectAsync(int id);
        Task<int> UpdateProjectAsync(UpdateProjectDTO model);
        Task<int> CreateCommentAsync(ProjectComment comment);
    }
}
