using System;
using forester.Domain.Entities;
using forester.Domain.Interfaces;
using Forester.DAL.data;
using Microsoft.EntityFrameworkCore;

namespace Forester.DAL.Repositories;

public class LogRepository : ILogRepository
{
    private ForesterDBContext context;
    public LogRepository(ForesterDBContext context)
    {
        this.context = context;
    }

    public async Task<List<Log>> GetAllLogsByUserID(int userID)
    {
        return await context.Log.Where(l => l.UserID == userID).ToListAsync();
    }

    public async Task InsertPredictionAsync(Log log)
    {
        await context.AddAsync(log);
    }
}
