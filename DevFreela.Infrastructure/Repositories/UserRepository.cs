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

        public async Task<User> GetByEmailAndPasswordAsync(string email, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);

            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);

            return user;
        }

        public async Task<List<User>> GetFreelancersAsync()
        {
            var freelancers = await _context.Users
                .Where(u => u.Role.Equals("freelancer"))
                .ToListAsync();

            return freelancers;
        }
    }
}