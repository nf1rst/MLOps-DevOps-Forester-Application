using System;
using forester.Domain.Entities;

namespace forester.Domain.Interfaces;

public interface ILogger
{
    Task InsertPrediction(ModelPrediction prediction, int result);
}
