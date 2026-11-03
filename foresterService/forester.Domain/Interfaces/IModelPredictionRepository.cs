using System;
using forester.Domain.Entities;

namespace forester.Domain.Interfaces;

public interface IModelPredictionRepository
{
    Task<ModelPrediction> InsertPredictionAsync(ModelPrediction prediction);
}
