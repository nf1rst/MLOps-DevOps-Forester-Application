using System;

namespace forester.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = String.Empty;
    public string PasswordHash { get; set; } = String.Empty;
    public string PasswordSalt { get; set; } = String.Empty;
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryDate { get; set; }
    public DateTime CreatedAt = DateTime.Now;

    public override string ToString()
    {
        return $"{Username} {PasswordHash} ";
    }

}
