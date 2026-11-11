using System;
using Forester.Application.Interfaces;
using Forester.Application.Options;
using Forester.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forester.Application.data;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection SetApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName)); //Microsoft.Extensions.Options.ConfigurationExtensions

        services.AddScoped<ILogService, LogService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPasswordHasherservice, PasswordHasherService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }

}
