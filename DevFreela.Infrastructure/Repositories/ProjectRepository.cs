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

        public async Task<List<ProjectDTO>> GetAllAsync()
        {
            var projects = await _dbContext.Projects.ToListAsync();

            var projectsDTO = new List<ProjectDTO>();

            foreach(var project in projects)
            {
                var projectDTO = new ProjectDTO(project.Id, project.Title, project.Description, project.Status);
                projectsDTO.Add(projectDTO);
            }

            return projectsDTO;
        }

        public async Task<ProjectDTO> GetByIdAsync(int id)
        {
            var project = _dbContext.Projects
               .Include(p => p.Client)
               .Include(p => p.Freelancer)
               .SingleOrDefault(p => p.Id == id);

            if (project == null) return null;

            var projectDTO = new ProjectDTO(project.Id, project.Title, project.Description, project.Status);

            return projectDTO;
        }


    }
}
