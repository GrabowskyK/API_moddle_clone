using ApiMoodleClone.Database.Entities;
using ApiMoodleClone.Users.UsersService;
using Microsoft.AspNetCore.Mvc;

namespace ApiMoodleClone.Users
{
    [Route("users")]
    [ApiController]
    public class UserController(IUsersService _UsersService) : Controller
    {
        private readonly IUsersService UsersService = _UsersService;

        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            var model = UsersService.GetUsers();
            return Ok(model);
        }

        // //Poniżej można sprawdzić czy działa token
        // [HttpGet("get"), Authorize(Roles = "User")]
        // public IActionResult GetUser() { }
    }
}
