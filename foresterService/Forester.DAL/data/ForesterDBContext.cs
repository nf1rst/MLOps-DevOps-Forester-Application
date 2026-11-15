
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

        builder.Entity<Log>()
            .HasOne(l => l.LogType)
            .WithMany(lt => lt.Logs)
            .HasForeignKey(l => l.LogTypeID);

        builder.Entity<LogType>()
        .HasData(
            new LogType() { Id = 1, Name = "User Activity" }
        );
    }
}
