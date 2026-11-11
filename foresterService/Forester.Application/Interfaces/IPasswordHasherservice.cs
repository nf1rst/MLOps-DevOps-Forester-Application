using System;

namespace Forester.Application.Interfaces;

public interface IPasswordHasherservice
{
    (string hash, string salt) HashPassword(string password);
    bool VerifyPassword(string password, string hash, string salt);
}
