using System;
using forester.Domain.Entities;
using forester.Domain.Interfaces;
using Forester.DAL.data;
namespace Forester.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public ILogRepository Logs { get; }

    public IUserRepository Users { get; }

    private readonly ForesterDBContext context;

    public UnitOfWork(
        ForesterDBContext context,
        ILogRepository logs,
        IUserRepository users
        )
    {
        this.context = context;
        Logs = logs;
        Users = users;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
