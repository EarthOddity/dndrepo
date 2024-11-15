using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("[controller]")]
public class AuthController(IConfiguration config, IAuthServiceAPI authService) : ControllerBase
{

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] Student student)
    {
        try
        {
            Student studentLog = await authService.ValidateStudent(student.id, student.password);
            string token = GenerateJwt(studentLog);

            return Ok(token);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    private string GenerateJwt(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(config["Jwt:Key"] ?? "");

        List<Claim> claims = GenerateClaims(user);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = config["Jwt:Issuer"],
            Audience = config["Jwt:Audience"]
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    private List<Claim> GenerateClaims(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, config["Jwt:Subject"] ?? ""),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("id", user.id.ToString()),
            new Claim("name", user.name),                                // First name
            new Claim("surname", user.surname),                          // Last name
            new Claim("email", user.email),        // Email
            new Claim("phoneNumber", user.phoneNumber.ToString())        // Phone number
        };
        return [.. claims];
    }


}