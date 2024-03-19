using ApiMoodleClone.Auth.AuthService;
using ApiMoodleClone.Database.Entities;
using ApiMoodleClone.Users.UsersService;
using Microsoft.AspNetCore.Mvc;

namespace ApiMoodleClone.Auth
{
    [Route("auth")]
    [ApiController]
    public class AuthController(IAuthService _AuthService, IUsersService _UsersService) : Controller
    {
        private readonly IAuthService UsersService = _AuthService;

        [HttpPost("register")]
        public IActionResult Register(User payload)
        {
            if (_UsersService.AddUser(payload))
            {
                return Ok("Sucessufly add " + payload.Username);
            }
            else
            {
                return BadRequest("Username is using!");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            if (_UsersService.VerifyLogin(user))
            {
                var token = _UsersService.CreateToken(user);
                return Ok(token);
            }
            else
            {
                return BadRequest("User are unknown or password is incorrect!");
            }
        }
    }
}
