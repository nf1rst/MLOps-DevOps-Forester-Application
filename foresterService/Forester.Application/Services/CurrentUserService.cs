using System;
using System.Security.Claims;
using Forester.Application.Interfaces;
using Microsoft.AspNetCore.Http;


namespace Forester.Application.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }
    public string? UserID => httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value;

    public string? Username => httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name).Value;

    public bool IsAuthenticated => httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
}
