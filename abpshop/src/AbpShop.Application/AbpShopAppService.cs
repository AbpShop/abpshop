using System;
using System.Collections.Generic;
using System.Text;
using AbpShop.Localization;
using Volo.Abp.Application.Services;

namespace AbpShop
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpShopAppService : ApplicationService
    {
        protected AbpShopAppService()
        {
            LocalizationResource = typeof(AbpShopResource);
        }
    }
}
