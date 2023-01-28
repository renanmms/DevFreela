namespace DevFreela.Core.DTOs
{
    public class UserDTO
    {
        public UserDTO(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
