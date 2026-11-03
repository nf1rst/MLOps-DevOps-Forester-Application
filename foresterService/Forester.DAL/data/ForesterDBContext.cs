using System;
using forester.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forester.DAL.data;

public class ForesterDBContext : DbContext
{
    public ForesterDBContext(DbContextOptions<ForesterDBContext> options) : base(options) { }

    public DbSet<ModelPrediction> ModelPrediction { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }
}
