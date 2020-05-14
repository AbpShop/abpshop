using AbpShop.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpShop
{
    [DependsOn(
        typeof(AbpShopEntityFrameworkCoreTestModule)
        )]
    public class AbpShopDomainTestModule : AbpModule
    {

    }
}