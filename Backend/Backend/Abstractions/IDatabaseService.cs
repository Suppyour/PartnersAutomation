using Backend.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Backend.Abstractions;

public class DatabaseService
{
    private readonly MyDbContext _myDbContext;

    public DatabaseService(MyDbContext myDbContext)
    {
        _myDbContext = myDbContext;
    }

    public async Task RecreateDatabase()
    {
        await _myDbContext.Database.EnsureDeletedAsync();
        await _myDbContext.Database.EnsureCreatedAsync();
    }
}