using System;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;

namespace Forester.DAL.data;

public class ForestDBContextFactory : IDesignTimeDbContextFactory<ForesterDBContext>
{
    public ForesterDBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ForesterDBContext>();
        optionsBuilder.UseSqlServer("Server=NINOSLAV;User Id=sa;Password=SQL;TrustServerCertificate=true;Database=ForesterDB");

        return new ForesterDBContext(optionsBuilder.Options);
    }
}
