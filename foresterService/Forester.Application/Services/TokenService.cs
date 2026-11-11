using forester.Domain.Entities;
using Forester.Application.Interfaces;
using Forester.Application.Options;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;


namespace Forester.Application.Services;

public class TokenService : ITokenService
{
    private readonly JwtSettings jWTSettings;
    private readonly IHttpContextAccessor httpContextAccessor;
    public TokenService(IOptions<JwtSettings> jwtSettings, IHttpContextAccessor httpContextAccessor)
    {
        this.jWTSettings = jwtSettings.Value;
        this.httpContextAccessor = httpContextAccessor;
    }
    public (string token, DateTime expiry) GenerateAccessToken(User user)
    {
        string secretKey = jWTSettings.SecretKey;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var expiry = DateTime.UtcNow.AddMinutes(jWTSettings.AccessTokenExpirationMinutes);

        var claims = new List<Claim>()
        {
          new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
          new Claim(JwtRegisteredClaimNames.Name, user.Username),
          new Claim(JwtRegisteredClaimNames.EmailVerified, "true")
        };

        var tokenDescriptor = new JwtSecurityToken(
            issuer: jWTSettings.Issuer,
            audience: jWTSettings.Audience,
            claims: claims,
            expires: expiry,
            signingCredentials: credentials
        );
        string token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        return (token, expiry);
    }

    public (string token, DateTime expiry) GenerateRefreshToken()
    {
        var randomBytes = RandomNumberGenerator.GetBytes(64);
        var token = Convert.ToBase64String(randomBytes);
        var expiry = DateTime.Now.AddMinutes(jWTSettings.RefreshTokenExpirationMinutes);
        return (token, expiry);
    }


}
