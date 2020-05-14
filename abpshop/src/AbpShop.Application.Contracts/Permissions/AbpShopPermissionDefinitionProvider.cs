using AbpShop.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpShop.Permissions
{
    public class AbpShopPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpShopPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpShopPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpShopResource>(name);
        }
    }
}
