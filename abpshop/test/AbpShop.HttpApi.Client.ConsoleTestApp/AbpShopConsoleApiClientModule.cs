using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace AbpShop.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(AbpShopHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class AbpShopConsoleApiClientModule : AbpModule
    {
        
    }
}
