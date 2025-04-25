using Backend.Entites;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

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