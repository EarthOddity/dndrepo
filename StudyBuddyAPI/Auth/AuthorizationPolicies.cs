using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

public static class AuthorizationPolicies{
    public static void AddPolicies(IServiceCollection services){
        services.AddAuthorization(options =>
        {
            options.AddPolicy("MustBeTutor", policy => policy.RequireClaim(ClaimTypes.Role, "Tutor"));
            options.AddPolicy("User", policy => policy.RequireClaim(ClaimTypes.Role, "User"));
        });
    }
}