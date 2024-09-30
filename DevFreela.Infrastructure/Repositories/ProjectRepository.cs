using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _context;

        public ProjectRepository(DevFreelaDbContext context)
        {
            _context = context;    
        }

         public async Task<int> AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            
            return project.Id;
        }

        public async Task<int> AddCommentAsync(ProjectComment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return comment.Id;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var exists = await _context.Projects.AnyAsync(p => p.Id == id);
            return exists;
        }

        public async Task<List<Project?>> GetAllAsync()
        {
            var projects = await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Where(p => !p.IsDeleted)
                .ToListAsync();

            return projects;
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == id);

            return project;
        }

        public async Task<Project?> GetDetailsById(int id)
        {
            var projects = await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Include(p => p.Comments)
                .SingleOrDefaultAsync(p => p.Id == id);

            return projects;
        }

        public async Task UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}