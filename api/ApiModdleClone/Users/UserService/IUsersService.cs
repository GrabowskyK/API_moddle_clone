using ApiMoodleClone.Database.Entities;

namespace ApiMoodleClone.Users.UsersService
{
    public interface IUsersService
    {
        public bool AddUser(User user);
        public bool VerifyLogin(User user);
        public string CreateToken(User user);
        public IEnumerable<User> GetUsers();
    }
}
