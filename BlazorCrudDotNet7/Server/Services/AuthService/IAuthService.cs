using BlazorCrudDotNet7.Shared.Entities;

namespace BlazorCrudDotNet7.Server.Services.AuthService;

public interface IAuthService
{
    public string CreateToken(User user);
}