
using forester.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forester.DAL.data;

public class ForesterDBContext : IdentityDbContext<User>
{
    public ForesterDBContext(DbContextOptions<ForesterDBContext> options) : base(options) { }

    public DbSet<Log> Log { get; set; }
    public DbSet<User> User { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
