using Backend.Entites;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    /// <inheritdoc />
    public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CartEntity> Cart { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        
        public async Task RecreateDatabase()
        {
            await Database.EnsureDeletedAsync();
            await Database.EnsureCreatedAsync();
        }
    }
}