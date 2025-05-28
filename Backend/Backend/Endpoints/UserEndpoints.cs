using Backend.Contracts;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace Backend.Endpoints;

public class UserEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("Register", Register);

        endpoints.MapPost("Login", Login);
        
        return endpoints;
    }

    private static async Task<IResult> Register(
        UserRequest request,
        UserService userService
        )
    {
        await userService.Register(request.Login, request.Email, request.Password);
        
        return Results.Ok();
    }
    private static async Task<IResult> Login(
        LoginUserRequest request,
        UserService userService)
    {
        try
        {
            var token = await userService.Login(request.Login, request.Password, request.Email);
            return Results.Ok(token);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
}