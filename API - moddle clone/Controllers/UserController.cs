using API___moddle_clone.Database;
using API___moddle_clone.Model;
using API___moddle_clone.Services.UserServ;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("AllUsers")]
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
                return BadRequest("User are unknown or password is incorrect!");
            }
        }


        //Poniżej można sprawdzić czy działa token
        [HttpGet("CheckRoleUser"), Authorize(Roles = "User")]
        public IActionResult CheckRoleUser()
        {
            if(!User.IsInRole("User"))
                return BadRequest("Nie posiadasz uprawnien Usera!");
            else
                return Ok("Otrzymałeś dostęp przez Usera");
        }

        [HttpGet("CheckRoleAdmin"), Authorize(Roles = "Admin")]
        public IActionResult CheckRoleAdmin()
        {
            if (!User.IsInRole("Admin"))
                return BadRequest("Nie posiadasz uprawnien Admina!");
            else
                return Ok("Otrzymałeś dostęp przez Admina");
        }

        [HttpGet("CheckRoleBoth"), Authorize(Roles = "Admin,User")]
        public IActionResult CheckBothRoles()
        {
            if (!User.IsInRole("User") || !User.IsInRole("Admin"))
                return BadRequest("Nie posiadasz uprawnien Usera!");
            else
                return Ok("Otrzymałeś dostęp przez admina i usera");
        }
    }
}
