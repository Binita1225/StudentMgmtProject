using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMgmtProject.UserService;
using StudentMgmtProject.UserService.Model;

namespace StudentMgmtProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] SignupVM model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = _userService.Register(model);
            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginVM model)
        {
            var token = _userService.Login(model);
            if (token == "User not found" || token == "Invalid password") return Unauthorized(token);


            return Ok(new { Token = token });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] SignupVM model)
        {
            return Ok(_userService.UpdateUser(id, model));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(_userService.DeleteUser(id));
        }

    }
}
