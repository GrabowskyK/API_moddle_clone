using API___moddle_clone.Database;
using API___moddle_clone.Model;
using API___moddle_clone.Services.UserServ;
using Microsoft.AspNetCore.Mvc;

namespace API___moddle_clone.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> logger;

        private readonly IUserService userService;
        private readonly IConfiguration configuration;

        public UserController(IUserService _userService, ILogger<UserController> _logger)
        {
            userService = _userService;
            logger = _logger;
            
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

        [HttpPost("Login")]
        public IActionResult Login(User user)
        {

            if (userService.VerifyLogin(user))
            {
                var token = userService.CreateToken(user);
                return Ok(token);
            }
            else
            {
                return Ok("User are unknown or password is incorrect!");
            }
        }
    }
}
