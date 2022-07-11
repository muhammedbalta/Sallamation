using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

public class TestAuthStateProvider : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        await Task.Delay(1500);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "John Doe"),
            new Claim(ClaimTypes.Role, "Administrator")
        };
        var anonymous = new ClaimsIdentity(claims, "testAuthType");
        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
    }
}