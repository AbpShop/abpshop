using AbpShop.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpShop.Permissions
{
    public class AbpShopPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpShopPermissions.Community, L("Group:Community"));
            myGroup.AddPermission(AbpShopPermissions.Community_Create, L("Permission:Community_Create"));
            myGroup.AddPermission(AbpShopPermissions.Community_Update, L("Permission:Community_Update"));
            myGroup.AddPermission(AbpShopPermissions.Community_Delete, L("Permission:Community_Delete"));
            myGroup.AddPermission(AbpShopPermissions.Community_List, L("Permission:Community_List"));
            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpShopPermissions.MyPermission1, L("Permission:MyPermission1"));
            //多租户
            /*
            myGroup.AddPermission(
    "BookStore_Author_Create",
    LocalizableString.Create<BookStoreResource>("Permission:BookStore_Author_Create"),
    multiTenancySide: MultiTenancySides.Tenant //set multi-tenancy side!
);*/
            //启用/禁用权限
            //myGroup.AddPermission("Author_Management", isEnabled: false);
            //子权限
            //var authorManagement = myGroup.AddPermission("Author_Management");
            //authorManagement.AddChild("Author_Management_Create_Books");
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpShopResource>(name);
        }
    }
}
