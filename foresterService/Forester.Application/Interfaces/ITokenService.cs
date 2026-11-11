using System;
using forester.Domain.Entities;

namespace Forester.Application.Interfaces;

public interface ITokenService
{
    (string token, DateTime expiry) GenerateAccessToken(User user);
    (string token, DateTime expiry) GenerateRefreshToken();
}
