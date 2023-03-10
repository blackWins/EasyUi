using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyUi.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class EasyUiDbContextFactory : IDesignTimeDbContextFactory<EasyUiDbContext>
{
    public EasyUiDbContext CreateDbContext(string[] args)
    {
        EasyUiEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<EasyUiDbContext>()
            //.UseSqlServer(configuration.GetConnectionString("Default"));
            .UseSqlite(configuration.GetConnectionString("Default"));

        return new EasyUiDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EasyUi.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
