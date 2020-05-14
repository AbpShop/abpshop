using AbpShop.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpShop.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpShopController : AbpController
    {
        protected AbpShopController()
        {
            LocalizationResource = typeof(AbpShopResource);
        }
    }
}