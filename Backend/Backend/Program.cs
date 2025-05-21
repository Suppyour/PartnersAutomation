using System.Text;
using Backend.Abstractions;
using Backend.Abstractions.Password;
using Backend.Jwt;
using Backend.Repositories;
using Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using Backend;
using Backend.Abstractions.Cart;
using Backend.Abstractions.Payment;
using Backend.Abstractions.Size;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => policy.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add XML documentation to Swagger
var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
builder.Services.AddSwaggerGen(c => { c.IncludeXmlComments(xmlPath); });

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();


// Configure JwtOptions
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtOptions"));

// Read JwtOptionvs
var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtSettings>();
if (jwtOptions == null || string.IsNullOrWhiteSpace(jwtOptions.SecretKey))
{
    throw new InvalidOperationException("JWT options are missing or invalid.");
}

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
builder.Services.AddAuthorization(options => { options.AddPolicy("Admin", policy => policy.RequireRole("Admin")); });

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
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<ISizeRepository, SizeRepository>();
builder.Services.AddScoped<ISizeService, SizeService>();

// Build the app
var app = builder.Build();

// Configure middleware
app.UseSwagger();
app.UseSwaggerUI();

// Use CORS policy
app.UseCors("AllowSpecificOrigin");

// Authentication and Authorization
app.UseAuthentication(); // обязательно ДО UseAuthorization
app.UseAuthorization();

app.MapControllers();
// ПОЛНАЯ ХУЙНЯ потом разобраться если заработает
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    db.Database.EnsureCreated();
}

app.Run();