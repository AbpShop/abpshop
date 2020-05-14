using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpShop.Data
{
    /* This is used if database provider does't define
     * IAbpShopDbSchemaMigrator implementation.
     */
    public class NullAbpShopDbSchemaMigrator : IAbpShopDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}