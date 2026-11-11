using System;

namespace forester.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ILogRepository Logs { get; }
    IUserRepository Users { get; }
    Task<int> SaveChangesAsync();
}
