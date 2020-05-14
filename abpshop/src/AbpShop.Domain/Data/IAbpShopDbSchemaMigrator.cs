using System.Threading.Tasks;

namespace AbpShop.Data
{
    public interface IAbpShopDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
