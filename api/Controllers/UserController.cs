using ApiMoodleClone.Models;
using ApiMoodleClone.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace ApiMoodleClone.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController(IUserService _userService) : Controller
    {
        private readonly IUserService userService = _userService;

        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            var model = userService.GetUsers();
            return Ok(model);
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if (userService.AddUser(user))
            {
                return Ok("Sucessufly add " + user.Username);
            }
            else
            {
                return BadRequest("Username is using!");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            if (userService.VerifyLogin(user))
            {
                var token = userService.CreateToken(user);
                return Ok(token);
            }
            else
            {
                return BadRequest("User are unknown or password is incorrect!");
            }
        }

        // //Poniżej można sprawdzić czy działa token
        // [HttpGet("get"), Authorize(Roles = "User")]
        // public IActionResult GetUser() { }
    }
}
