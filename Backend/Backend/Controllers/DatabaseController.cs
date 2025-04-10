using Backend.Abstractions;
using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]


public class DatabaseController : ControllerBase
{
    private readonly DatabaseService databaseService;

    public DatabaseController(DatabaseService databaseService)
    {
        this.databaseService = databaseService;
    }

    [HttpPost]
    public async Task<ActionResult> RecreateDatabase()
    {
        await databaseService.RecreateDatabase();
        return Ok();
    }
}