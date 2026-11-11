using System;
using System.Data.Common;
using forester.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Forester.DAL.data;

public class ForesterDBContext : DbContext
{
    public ForesterDBContext(DbContextOptions<ForesterDBContext> options) : base(options) { }

    public DbSet<LogType> LogType { get; set; }
    public DbSet<Log> Log { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Log>()
        .HasOne(l => l.LogType)
        .WithMany(lt => lt.Logs);

        modelBuilder.Entity<LogType>()
        .HasData(
            new LogType() { Id = 1, Name = "Information" }
        );
    }
}
