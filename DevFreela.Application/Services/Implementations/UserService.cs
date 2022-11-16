using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Core.Entities;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int CreateUser(NewUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
        }

        public UserDetailsViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            var userDetails = new UserDetailsViewModel(user.FullName, user.Email);
            return userDetails;
        }

        public void Login(UserLoginInputModel inputModel)
        {
            throw new NotImplementedException();
        }
    }
}
