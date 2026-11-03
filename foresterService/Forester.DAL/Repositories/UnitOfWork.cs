using System;
using forester.Domain.Interfaces;
using Forester.DAL.data;
namespace Forester.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public IModelPredictionRepository Predictions { get; }
    public ILogger Logger { get; }

    private readonly ForesterDBContext context;

    public UnitOfWork(
        ForesterDBContext context,
        IModelPredictionRepository predictions,
        ILogger logger
        )
    {
        this.context = context;
        Predictions = predictions;
        Logger = logger;
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
