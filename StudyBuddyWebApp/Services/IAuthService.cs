using System.Security.Claims;

public interface IAuthService
{
    public Task LoginAsync(int id, string password);
    public Task LogoutAsync();
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    public Task<ClaimsPrincipal> GetAuthAsync();

}