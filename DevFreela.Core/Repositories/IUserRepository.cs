using DevFreela.Core.DTOs;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<UserDTO> GetById(int id);
    }
}
