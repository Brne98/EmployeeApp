using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlazorCrudDotNet7.Server.Data;
using BlazorCrudDotNet7.Shared.Entities;
using Microsoft.IdentityModel.Tokens;

namespace BlazorCrudDotNet7.Server.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(DataContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Username)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims, 
            expires: DateTime.Now.AddDays(1), 
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}