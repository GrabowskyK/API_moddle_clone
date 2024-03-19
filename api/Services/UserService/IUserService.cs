using ApiMoodleClone.Models;

namespace ApiMoodleClone.Services.UserService
{
    public interface IUserService
    {
        public bool AddUser(User user);
        public bool VerifyLogin(User user);
        public string CreateToken(User user);
        public IEnumerable<User> GetUsers();
    }
}
