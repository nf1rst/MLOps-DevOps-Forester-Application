using System;
using forester.Domain.Interfaces;
using Forester.DAL.data;
using Forester.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Forester.DAL;

public static class DALServiceExtensions
{
    public static IServiceCollection SetDALServices(this IServiceCollection services, string connectiontring)
    {
        services.AddDbContext<ForesterDBContext>(opt => opt.UseSqlite(connectiontring));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ILogRepository, LogRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
