using Backend.Abstractions;
using Backend.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

/// <summary>
/// Контроллер для администрирования пользователей. Реализует управление пользователями (получение, обновление, удаление).
/// </summary>
[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор для инициализации контроллера.
    /// </summary>
    /// <param name="userService">Сервис для работы с пользователями.</param>
    public AdminController(IUserService userService) => _userService = userService;
    
    /// <summary>
    /// Получение списка всех пользователей.
    /// </summary>
    /// <returns>Список пользователей с основными данными (Id, Email, Login, Password).</returns>
    /// <remarks>
    /// <b>Внимание:</b> Функциональность пока не работает. Для получения списка пользователей метод нужно доработать.
    /// </remarks>
    [HttpGet("users")]
    public async Task<ActionResult<List<UserResponce>>> GetAll()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users.Select(u => new UserResponce(u.Id, u.Password, u.Email, u.Login)));
    }

    /// <summary>
    /// Обновление данных пользователя.
    /// </summary>
    /// <param name="id">Идентификатор пользователя, которого нужно обновить.</param>
    /// <param name="req">Данные для обновления пользователя (пароль, логин, email).</param>
    /// <returns>Идентификатор обновленного пользователя.</returns>
    /// <remarks>
    /// <b>Внимание:</b> Функциональность пока не работает. Метод нужно доработать.
    /// </remarks>
    [HttpPut("users/{id:guid}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserRequest req)
    {
        var updatedId = await _userService.UpdateUser(id, req.Password, req.Login, req.Email);
        return Ok(updatedId);
    }

    /// <summary>
    /// Удаление пользователя.
    /// </summary>
    /// <param name="id">Идентификатор пользователя, которого нужно удалить.</param>
    /// <returns>Идентификатор удаленного пользователя.</returns>
    /// <remarks>
    /// <b>Внимание:</b> Функциональность пока не работает. Метод нужно доработать.
    /// </remarks>
    [HttpDelete("users/{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var deletedId = await _userService.DeleteUser(id);
        return Ok(deletedId);
    }
}
