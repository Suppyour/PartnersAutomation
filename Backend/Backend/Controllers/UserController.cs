using Backend.Contracts;
using Backend.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользователями. Реализует регистрацию и вход пользователей.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Конструктор для инициализации контроллера.
        /// </summary>
        /// <param name="userService">Сервис для работы с пользователями.</param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        /// <summary>
        /// Регистрация нового пользователя.
        /// </summary>
        /// <param name="request">Данные для регистрации нового пользователя.</param>
        /// <returns>Ответ с ID зарегистрированного пользователя и сообщением.</returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRequest request)
        {
            var userId = await _userService.Register(request.Login, request.Email, request.Password);
            
            return Ok(new { message = "Пользователь зарегистрирован", userId });
        }

        
        /// <summary>
        /// Вход пользователя в систему.
        /// </summary>
        /// <param name="request">Данные для входа (email и пароль).</param>
        /// <returns>Ответ с результатом входа (например, токен или сообщение об ошибке).</returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            var result = await _userService.Login(request.Login, request.Password, request.Email);
            
            return Ok(result);
        }
    }
}
