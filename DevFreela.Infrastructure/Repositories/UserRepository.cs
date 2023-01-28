using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateUserAsync(UserDTO userDTO)
        {
            var user = new User(userDTO.FullName, userDTO.Email, userDTO.BirthDate);
            _dbContext.Users.Add(user);
            var numberOfEntries = await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
            var userDetails = new UserDTO(user.FullName, user.Email);

            return userDetails;
        }
    }
}
