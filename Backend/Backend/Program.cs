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
builder.Services.AddDbContext<UsersDbContext>(options =>
{
    var userDbConnection = Environment.GetEnvironmentVariable("USER_DB_CONNECTION_STRING") ??
                           builder.Configuration.GetConnectionString("UserDb");

    options.UseNpgsql(userDbConnection);
});

builder.Services.AddDbContext<CategoryDbContext>(options =>
{
    var categoryDbConnection = Environment.GetEnvironmentVariable("CATEGORY_DB_CONNECTION_STRING") ??
                               builder.Configuration.GetConnectionString("CategoryDb");

    options.UseNpgsql(categoryDbConnection);
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