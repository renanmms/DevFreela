using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _context;
        public UserRepository(DevFreelaDbContext context)
        {
            _context = context;    
        }

        public async Task<int> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.Skills)
                    .ThenInclude(u => u.Skill)
                .SingleOrDefaultAsync(u => u.Id == id);

            return user;
        }
    }
}