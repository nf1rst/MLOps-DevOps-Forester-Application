using System;
using forester.Domain.Entities;

namespace Forester.Application.Interfaces;

public interface ILoggerService
{
    Task LogSinglePredition(ModelPrediction modelPrediction, int result);
}
