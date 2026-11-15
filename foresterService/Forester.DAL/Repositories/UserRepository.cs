using System;
using forester.Domain.Entities;
using forester.Domain.Interfaces;
using Forester.DAL.data;
using Microsoft.EntityFrameworkCore;

namespace Forester.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ForesterDBContext context;
    public UserRepository(ForesterDBContext context)
    {
        this.context = context;
    }

    public async Task<User> GetUserByUsername(string username)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.UserName == username);
    }

    public async Task InsertUserAsync(User user)
    {
        await context.Users.AddAsync(user);
    }

    public Task UpdateUser(User user)
    {
        context.Users.Update(user);
        return Task.CompletedTask;
    }

    public async Task<bool> UsernameInUse(string username)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.UserName == username) == null ? false : true;
    }
}
