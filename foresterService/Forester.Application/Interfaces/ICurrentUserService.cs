using System;

namespace Forester.Application.Interfaces;

public interface ICurrentUserService
{
    string? UserID { get; }
    string? Username { get; }
    bool IsAuthenticated { get; }
}
