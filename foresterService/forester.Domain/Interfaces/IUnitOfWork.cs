using System;

namespace forester.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IModelPredictionRepository Predictions { get; }
    Task<int> SaveChangesAsync();
}
