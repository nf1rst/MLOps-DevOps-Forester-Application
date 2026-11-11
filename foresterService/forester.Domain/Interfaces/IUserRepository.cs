using System;
using forester.Domain.Entities;

namespace forester.Domain.Interfaces;

public interface IUserRepository
{
    Task InsertUserAsync(User user);
    Task<bool> UsernameInUse(string username);
    Task<User> GetUserByUsername(string username);
    Task UpdateUser(User user);
}
