using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AbpShop.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpShopEntityFrameworkCoreModule)
        )]
    public class AbpShopEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpShopMigrationsDbContext>();
        }
    }
}
