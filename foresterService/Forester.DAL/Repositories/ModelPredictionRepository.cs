using System;
using forester.Domain.Entities;
using forester.Domain.Interfaces;
using Forester.DAL.data;
using Microsoft.EntityFrameworkCore;

namespace Forester.DAL.Repositories;

public class ModelPredictionRepository : IModelPredictionRepository
{
    private ForesterDBContext context;
    public ModelPredictionRepository(ForesterDBContext context)
    {
        this.context = context;
    }
    public async Task<ModelPrediction> InsertPredictionAsync(ModelPrediction prediction)
    {
        await context.AddAsync(prediction);
        return prediction;
    }
}
