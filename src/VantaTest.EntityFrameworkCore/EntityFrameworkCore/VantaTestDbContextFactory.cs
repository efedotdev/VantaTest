using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VantaTest.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class VantaTestDbContextFactory : IDesignTimeDbContextFactory<VantaTestDbContext>
{
    public VantaTestDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        VantaTestEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<VantaTestDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new VantaTestDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../VantaTest.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables();

        return builder.Build();
    }
}
