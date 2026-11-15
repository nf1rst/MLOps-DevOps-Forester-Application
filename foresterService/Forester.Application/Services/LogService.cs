using System;
using forester.Domain.Entities;
using forester.Domain.Interfaces;

namespace Forester.Application.Services;

public class LogService : ILogService
{
    private readonly IUnitOfWork uow;
    public LogService(IUnitOfWork uow)
    {
        this.uow = uow;
    }

    public async Task InsertSingleUserPredictionRequest(UserInputs prediction, int result, string username)
    {
        String text = $"{prediction.Elevation},{prediction.Aspect},{prediction.Slope}, {prediction.Horizontal_Distance_To_Hydrology}, {prediction.Vertical_Distance_To_Hydrology}, {prediction.Horizontal_Distance_To_Roadways}, {prediction.Hillshade_9am}, {prediction.Hillshade_Noon}, {prediction.Hillshade_3pm}, {prediction.Horizontal_Distance_To_Fire_Points}, {prediction.Wilderness_Area},  {prediction.Soil_Type}, {username}";
        Log log = new Log() { LogTypeID = 1, Text = text };
        await uow.Logs.InsertPredictionAsync(log);
        await uow.SaveChangesAsync();
    }

    //Get all logs by individual user
}
