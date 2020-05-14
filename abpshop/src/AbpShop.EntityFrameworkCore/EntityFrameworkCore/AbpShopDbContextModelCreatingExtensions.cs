using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace AbpShop.EntityFrameworkCore
{
    public static class AbpShopDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpShop(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(AbpShopConsts.DbTablePrefix + "YourEntities", AbpShopConsts.DbSchema);

            //    //...
            //});
        }
    }
}