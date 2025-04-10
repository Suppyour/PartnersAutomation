using Backend.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Backend.Abstractions;

public class DatabaseService
{
    private readonly UsersDbContext _usersDbContext;

    public DatabaseService(UsersDbContext usersDbContext)
    {
        _usersDbContext = usersDbContext;
    }

    public async Task RecreateDatabase()
    {
        await _usersDbContext.Database.EnsureDeletedAsync();
        await _usersDbContext.Database.EnsureCreatedAsync();
    }
}