using System;
using Forester.Application.Interfaces;
using Forester.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forester.Application.data;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection SetApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ILogService, LogService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }

}
