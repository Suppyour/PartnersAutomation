using Backend.Abstractions;
using Backend.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateUser([FromBody] UserRequest request)
    {
        var (user, error) = Models.User.Create(
            Guid.NewGuid(),
            request.Login,
            request.Email,
            request.Password);
        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var userId = await _userService.CreateUser(user);

        return Ok(userId);
    }

    [HttpGet]
    public async Task<ActionResult<List<UserResponce>>> GetUsers()
    {
        var users = await _userService.GetAllUsers();

        var responce = users.Select(u => new UserResponce(u.Id, u.Password, u.Email, u.Login));

        return Ok(responce);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateUser([FromRoute] Guid id, [FromBody] UserRequest request)
    {
        var userId = await _userService.UpdateUser(id, request.Password, request.Login, request.Email);

        return Ok(userId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteUser([FromRoute] Guid id)
    {
        return Ok(await _userService.DeleteUser(id));
    }
}