using BlazorCrudDotNet7.Server.Data;
using BlazorCrudDotNet7.Server.Services.AuthService;
using BlazorCrudDotNet7.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudDotNet7.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly DataContext _context;

    public AuthController(IAuthService authService, DataContext context)
    {
        _authService = authService;
        _context = context;
    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(User request)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == request.Username);
        
        if (user is null)
            return BadRequest("User does not exist!");
        
        if(user.Password != request.Password)
            return BadRequest("Password incorrect!");
        
        var token = _authService.CreateToken(user);

        return Ok(token);
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(User request)
    {
        var user = new User
        {
            Username = request.Username,
            Password = request.Password
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok(user);
    }
}