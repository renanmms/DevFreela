using DevFreela.Core.Entities;

namespace DevFreela.Core.DTOs
{
    public class UserDTO
    {
        public UserDTO(string fullName, string email, string password, DateTime birthDate, string role)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Role = role;
            Password = password;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Role { get; private set; }
        public string Password { get; private set; }

        public static UserDTO FromEntity(User user){
            return new UserDTO(user.FullName, user.Email, user.Password, user.BirthDate, user.Role);
        }
    }
}
