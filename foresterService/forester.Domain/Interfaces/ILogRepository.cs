using System;
using forester.Domain.Entities;

namespace forester.Domain.Interfaces;

public interface ILogRepository
{
    Task InsertPredictionAsync(Log log);
    Task<List<Log>> GetAllLogsByUserUsername(string username);
}
