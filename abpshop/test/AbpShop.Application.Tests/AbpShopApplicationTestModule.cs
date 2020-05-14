using Volo.Abp.Modularity;

namespace AbpShop
{
    [DependsOn(
        typeof(AbpShopApplicationModule),
        typeof(AbpShopDomainTestModule)
        )]
    public class AbpShopApplicationTestModule : AbpModule
    {

    }
}