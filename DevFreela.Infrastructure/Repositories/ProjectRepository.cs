using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public ProjectRepository(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
            _dbContext = dbContext;
        }

        public async Task<int> CreateCommentAsync(ProjectComment comment)
        {
            await _dbContext.ProjectComments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();

            return comment.Id;
        }

        public async Task<int> CreateProjectAsync(Project project)
        {
            _dbContext.Projects.Add(project);
            var numberOfEntries = await _dbContext.SaveChangesAsync();
            return project.Id;
        }

        public async Task<ProjectStatusEnum> DeleteProjectAsync(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Cancel();
            await _dbContext.SaveChangesAsync();

            return project.Status;
        }

        public async Task<ProjectStatusEnum> FinishProjectAsync(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Finish();
            await _dbContext.SaveChangesAsync();

            return project.Status;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            var projects = await _dbContext.Projects.ToListAsync();

            return projects;
        }

        public async Task<ProjectDTO> GetByIdAsync(int id)
        {
            var project = _dbContext.Projects
               .Include(p => p.Client)
               .Include(p => p.Freelancer)
               .SingleOrDefault(p => p.Id == id);

            if (project == null) return null;

            var projectDTO = new ProjectDTO(project.Id, project.Title, project.Description, project.Status.ToString());

            return projectDTO;
        }

        public async Task<ProjectStatusEnum> StartProjectAsync(int id)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == id);
            project.Start();
            await _dbContext.SaveChangesAsync();

            return project.Status;
        }

        public async Task<int> UpdateProjectAsync(UpdateProjectDTO model)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == model.Id);
            project.Update(model.Title, model.Description, model.TotalCost);
            await _dbContext.SaveChangesAsync();

            return project.Id;
        }
    }
}
