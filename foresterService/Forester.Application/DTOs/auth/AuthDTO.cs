using System;

namespace Forester.Application.DTOs.auth;

public class AuthDTO
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime AccessTokenExpiry { get; set; }
    public DateTime RefreshTokenExpiry { get; set; }

}
