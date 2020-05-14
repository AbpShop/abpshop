using Volo.Abp.Settings;

namespace AbpShop.Settings
{
    public class AbpShopSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AbpShopSettings.MySetting1));
        }
    }
}
