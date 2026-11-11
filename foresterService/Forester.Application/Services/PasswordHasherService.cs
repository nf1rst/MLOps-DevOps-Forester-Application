using System;
using System.Security.Cryptography;
using Forester.Application.Interfaces;

namespace Forester.Application.Services;

public class PasswordHasherService : IPasswordHasherservice
{
    private int saltSize = 32;
    private int iterations = 10000;
    private static readonly HashAlgorithmName algorithm = HashAlgorithmName.SHA256;
    private int hashSize = 32;
    public (string hash, string salt) HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(saltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, algorithm, hashSize);
        return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
    }

    public bool VerifyPassword(string password, string hash, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);
        var hashBytes = Convert.FromBase64String(hash);

        var computedHash = Rfc2898DeriveBytes.Pbkdf2(password, saltBytes, iterations, algorithm, hashSize);

        return CryptographicOperations.FixedTimeEquals(computedHash, hashBytes);
    }
}
