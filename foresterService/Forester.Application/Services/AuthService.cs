using System;
using forester.Domain.Entities;
using forester.Domain.Interfaces;
using Forester.Application.DTOs;
using Forester.Application.DTOs.auth;
using Forester.Application.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Forester.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork uow;
    private readonly IPasswordHasherservice passwordHasher;
    private readonly ITokenService tokenService;

    public AuthService(IUnitOfWork uow, IPasswordHasherservice passwordHasher, ITokenService tokenService)
    {
        this.uow = uow;
        this.tokenService = tokenService;
        this.passwordHasher = passwordHasher;
    }
    public async Task<AuthDTO> LoginAsync(string username, string password)
    {
        User user = await uow.Users.GetUserByUsername(username);
        if (user is null)
        {
            throw new Exception("User does not exist");
        }

        if (!passwordHasher.VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
        {
            throw new Exception("Incorrect password");
        }
        var (accessToken, accessTokenExpiry) = tokenService.GenerateAccessToken(user);
        var (refreshToken, refreshExpiry) = tokenService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryDate = refreshExpiry;

        await uow.Users.UpdateUser(user);
        await uow.SaveChangesAsync();

        return new AuthDTO() { AccessToken = accessToken, RefreshToken = refreshToken, RefreshTokenExpiry = refreshExpiry, AccessTokenExpiry = accessTokenExpiry };

    }

    public async Task<UserDTO> RegisterAsync(string username, string password)
    {
        //check if the username already exists 
        if (await uow.Users.UsernameInUse(username))
        {
            //username vec postoji 
        }
        var (hash, salt) = passwordHasher.HashPassword(password);

        User user = new User()
        {
            Username = username,
            PasswordHash = hash,
            PasswordSalt = salt
        };
        await uow.Users.InsertUserAsync(user);
        await uow.SaveChangesAsync();
        return new UserDTO() { Username = username, Password = password };
    }
}
