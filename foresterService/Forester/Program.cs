using forester.Domain.Entities;
using Forester.Application.data;
using Forester.Components;
using Forester.DAL;
using Forester.DAL.data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.SetApplicationServices(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
}).AddIdentityCookies();

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<ForesterDBContext>()
    .AddSignInManager();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/login";
    options.AccessDeniedPath = "/access-denied";
});

var dbFolder = Path.Combine(builder.Environment.ContentRootPath, "forester-data");
Directory.CreateDirectory(dbFolder); // Ensures the folder exists if missing

var dbPath = Path.Combine(dbFolder, "forester.db");
var connectionString = $"Data Source={dbPath}";

builder.Services.SetDALServices(connectionString);

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// using (var scope = app.Services.CreateScope())
// {
//     var context = scope.ServiceProvider.GetRequiredService<ForesterDBContext>();
//     context.Database.Migrate();
// }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();


app.MapControllers();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
