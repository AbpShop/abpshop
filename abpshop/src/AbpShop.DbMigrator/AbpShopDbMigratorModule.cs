using AbpShop.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpShop.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpShopEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpShopApplicationContractsModule)
        )]
    public class AbpShopDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
