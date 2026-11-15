using System;
using forester.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Forester.Application.Services;

public interface ILogService
{
    Task InsertSingleUserPredictionRequest(UserInputs prediction, int result, string username);
}
