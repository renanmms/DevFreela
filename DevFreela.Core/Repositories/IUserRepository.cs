using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<int> AddAsync(User user);
        Task<List<User>> GetAllAsync();
        Task<List<User>> GetFreelancersAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAndPasswordAsync(string email, string password);
        Task<User> GetByEmailAsync(string email);
    }
}