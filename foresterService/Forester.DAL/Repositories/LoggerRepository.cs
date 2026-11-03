using System;
using forester.Domain.Entities;
using forester.Domain.Interfaces;
using Forester.DAL.data;

namespace Forester.DAL.Repositories;

public class LoggerRepository : ILogger
{
    private ForesterDBContext context;

    public LoggerRepository(ForesterDBContext context)
    {
        this.context = context;
    }

    public async Task InsertPrediction(ModelPrediction prediction, int result)
    {
        await context.AddAsync(prediction);
    }
}
