using API___moddle_clone.Database;
using API___moddle_clone.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace API___moddle_clone.Services.UserServ
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext databaseContext;
        private readonly IConfiguration configuration;
        public UserService(DatabaseContext _databaseContext, IConfiguration _configuration)
        {
            databaseContext = _databaseContext;
            configuration = _configuration;
        }

        public IEnumerable<User> GetUsers() => databaseContext.Users;

        public bool AddUser(User user)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            User newUser = new User(user.Username, passwordHash, user.Role);
            if (databaseContext.Users.Any(u => u.Username == user.Username))
            {
                return false;
            }
            else
            {
                databaseContext.Users.Add(newUser);
                databaseContext.SaveChanges();
                return true;
            }
            
        }

        public bool VerifyLogin(User user)
        {
            var userTemp = databaseContext.Users.Where(u => u.Username == user.Username).FirstOrDefault();
            if (userTemp != null && BCrypt.Net.BCrypt.Verify(user.PasswordHash, userTemp.PasswordHash))
                return true;
            else
                return false;
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
