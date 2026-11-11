using System;
using forester.Domain.Entities;
using Forester.Application.DTOs;
using Forester.Application.DTOs.auth;

namespace Forester.Application.Interfaces;

public interface IAuthService
{
    //register, login, regreshToken
    Task<UserDTO> RegisterAsync(string username, string password);
    Task<AuthDTO> LoginAsync(string username, string password);
}
