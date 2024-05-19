using meme_api.Models;
using meme_api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace meme_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("token")]
        [AllowAnonymous]
        public async Task<IActionResult> Token()
        {
            var dbUser = await _userService.GetByEmail("email@email.com");

            if (dbUser == null)
            {
                return BadRequest(new { message = "Email or Password is incorrect" });
            }

            var token = _userService.GetToken(dbUser);
            if (token == null || token == string.Empty)
            {
                return BadRequest(new { message = "Email or Password is incorrect" });
            }

            return Ok(token);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserDTO user)
        {
            var dbUser = await _userService.GetByEmail(user.Email);

            if(dbUser == null) 
            { 
                return BadRequest(new { message = "Email or Password is incorrect" }); 
            }

            if(user.Password != dbUser.Password)
            {
                return BadRequest(new { message = "Email or Password is incorrect" });
            }

            var token = _userService.GetToken(dbUser);
            if (token == null || token == string.Empty)
            {
                return BadRequest(new { message = "Email or Password is incorrect" });
            }

            return Ok(token);
        }
    }
}
