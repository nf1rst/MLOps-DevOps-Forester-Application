using System.Security.Claims;
using Forester.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forester
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService AuthService;
        public AuthController(IAuthService authService)
        {
            this.AuthService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] string username, [FromForm] string password)
        {
            try
            {
                var user = await AuthService.LoginAsync(username, password);
                var claims = new List<Claim>
                {
                  new Claim(ClaimTypes.Name, username),
                  new Claim(ClaimTypes.NameIdentifier, user.AccessToken)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return LocalRedirect("/");

            }
            catch (Exception e)
            {
                return LocalRedirect("/login");
            }
        }
    }
}
