using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<UserDTO> GetByIdAsync(int id);
        Task<int> CreateUserAsync(UserDTO user);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
