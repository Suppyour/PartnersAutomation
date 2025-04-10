using Backend.Entites;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base (options)
        {
            
        }
        public DbSet<UserEntity> Users { get; set; }

        public async Task RecreateDatabase()
        {
            await Database.EnsureDeletedAsync();
            await Database.EnsureCreatedAsync();
        }
    }
}
