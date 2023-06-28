using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorCrudDotNet7.Client;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    // private readonly ILocalStorageService _localStorage;
    // private readonly HttpClient _http;

    // public CustomAuthStateProvider(ILocalStorageService localStorage, HttpClient http)
    // {
    //     _localStorage = localStorage;
    //     _http = http;
    // }
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string token = "";

        var identity = new ClaimsIdentity();
        // var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");

        var user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;
    }

    public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
    }
    
    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}