using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbpShop.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class AbpShopMigrationsDbContextFactory : IDesignTimeDbContextFactory<AbpShopMigrationsDbContext>
    {
        public AbpShopMigrationsDbContext CreateDbContext(string[] args)
        {
            AbpShopEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<AbpShopMigrationsDbContext>()
                //.UseSqlServer(configuration.GetConnectionString("Default"));
                .UseMySql(configuration.GetConnectionString("Default"));

            return new AbpShopMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
