using API___moddle_clone.Model;

namespace API___moddle_clone.Services.UserServ
{
    public interface IUserService
    {
        public bool AddUser(User user);
        public bool VerifyLogin(User user);
        public string CreateToken(User user);
    }
}
