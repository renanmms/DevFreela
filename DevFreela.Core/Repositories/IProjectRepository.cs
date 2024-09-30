using System;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project?>> GetAllAsync();
        Task<Project?> GetDetailsById(int id);
        Task<Project?> GetByIdAsync(int id);
        Task<int> AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task<int> AddCommentAsync(ProjectComment comment);
        Task<bool> ExistsAsync(int id);
    }
}