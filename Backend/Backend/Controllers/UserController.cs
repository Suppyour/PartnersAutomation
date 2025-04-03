using System.Diagnostics;
using Backend.Abstractions;
using Backend.Contracts;
using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService; 
    }

    [HttpGet]
    public async Task<ActionResult<List<UserResponce>>> GetUsers()
    {
        var users = await _userService.GetAllUsers();

        var responce = users.Select(b => new UserResponce(b.Id, b.Password, b.Email, b.Login));

        return Ok(responce);
    }
}