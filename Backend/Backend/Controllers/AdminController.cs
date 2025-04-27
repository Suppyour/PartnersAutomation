using Backend.Abstractions;
using Backend.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IUserService _userService;
    public AdminController(IUserService userService) => _userService = userService;
    
    [HttpGet("users")]
    public async Task<ActionResult<List<UserResponce>>> GetAll()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users.Select(u => new UserResponce(u.Id, u.Password, u.Email, u.Login)));
    }

    [HttpPut("users/{id:guid}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserRequest req)
    {
        var updatedId = await _userService.UpdateUser(id, req.Password, req.Login, req.Email);
        return Ok(updatedId);
    }

    [HttpDelete("users/{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var deletedId = await _userService.DeleteUser(id);
        return Ok(deletedId);
    }
}