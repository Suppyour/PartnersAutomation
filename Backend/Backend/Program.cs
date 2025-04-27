using System.Text;
using Backend.Abstractions;
using Backend.Abstractions.Password;
using Backend.Jwt;
using Backend.Repositories;
using Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure JwtOptions
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtOptions"));

// Read JwtOptions
var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtSettings>();
var key = Encoding.UTF8.GetBytes(jwtOptions.SecretKey);

// Configure Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// Configure Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});

// Configure DbContext
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
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

// Build the app
var app = builder.Build();

// Configure middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication(); // обязательно ДО UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.Run();
