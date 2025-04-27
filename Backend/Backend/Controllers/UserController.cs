using Backend.Contracts;
using Backend.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRequest request)
        {
            var userId = await _userService.Register(request.Login, request.Email, request.Password);
            
            return Ok(new { message = "Пользователь зарегистрирован", userId });
        }

        
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            var result = await _userService.Login(request.Email, request.Password);
            
            return Ok(result);
        }

    }
}