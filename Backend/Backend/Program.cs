using Backend;
using Backend.Abstractions;
using Backend.Repositories;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContexts
builder.Services.AddDbContext<MyDbContext>(options =>
{
    var connection = Environment.GetEnvironmentVariable("MY_DB_CONNECTION_STRING") ??
                           builder.Configuration.GetConnectionString("MyDb");

    options.UseNpgsql(connection);
});

// Register services and repositories
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Build the app
var app = builder.Build();

// Configure middleware
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();