using DevFreela.Core.DTOs;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<UserDTO> GetByIdAsync(int id);
        Task<int> CreateUserAsync(UserDTO user);
    }
}
