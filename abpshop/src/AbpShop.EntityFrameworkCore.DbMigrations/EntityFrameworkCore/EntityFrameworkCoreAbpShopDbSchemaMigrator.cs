using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpShop.Data;
using Volo.Abp.DependencyInjection;

namespace AbpShop.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpShopDbSchemaMigrator
        : IAbpShopDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpShopDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpShopMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpShopMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}