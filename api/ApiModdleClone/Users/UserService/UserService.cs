using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiMoodleClone.Database;
using ApiMoodleClone.Database.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ApiMoodleClone.Users.UsersService
{
    public class UsersService(DatabaseContext _databaseContext, IConfiguration _configuration)
        : IUsersService
    {
        public IEnumerable<User> GetUsers() => _databaseContext.Users;

        public bool AddUser(User user)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            User newUser = new(user.Username, passwordHash, user.Role);

            if (_databaseContext.Users.Any(u => u.Username == user.Username))
            {
                return false;
            }
            else
            {
                _databaseContext.Users.Add(newUser);
                _databaseContext.SaveChanges();
                return true;
            }
        }

        public bool VerifyLogin(User user)
        {
            var userTemp = _databaseContext
                .Users.Where(u => u.Username == user.Username)
                .FirstOrDefault();

            if (
                userTemp != null
                && BCrypt.Net.BCrypt.Verify(user.PasswordHash, userTemp.PasswordHash)
            )
                return true;
            else
                return false;
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Username),
                new(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!)
            );

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
