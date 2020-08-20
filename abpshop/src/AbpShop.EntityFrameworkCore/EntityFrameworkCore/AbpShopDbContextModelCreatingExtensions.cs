using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using AbpShop.Merchant;
using Volo.Abp.EntityFrameworkCore.Modeling;

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
            builder.Entity<Community>(b =>
            {
                b.ToTable(AbpShopConsts.DbTablePrefix + "Community", AbpShopConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(20);
            });
            builder.Entity<AbpArticle>();
            builder.Entity<AbpArticleCategory>();
            builder.Entity<AbpArticleContent>();
            builder.Entity<AbpCache>();
            builder.Entity<AbpDiy>();
            builder.Entity<AbpExpress>();
            builder.Entity<AbpQrcode>();
            builder.Entity<AbpRoutineAccessToken>();
            builder.Entity<AbpRoutineFormId>();
            builder.Entity<AbpRoutineQrcode>();
            builder.Entity<AbpShippingTemplates>();
            builder.Entity<AbpShippingTemplatesFree>();
            builder.Entity<AbpShippingTemplatesRegion>();
            builder.Entity<AbpSmsRecord>();
            builder.Entity<AbpStoreBargain>();
            builder.Entity<AbpStoreBargainUser>();
            builder.Entity<AbpStoreBargainUserHelp>();
            builder.Entity<AbpStoreCart>();
            builder.Entity<AbpStoreCategory>();
            builder.Entity<AbpStoreCombination>();
            builder.Entity<AbpStoreCoupon>();
            builder.Entity<AbpStoreCouponIssue>();
            builder.Entity<AbpStoreCouponIssueUser>(b => b.HasKey(t => new { t.Uid, t.IssueCouponId }));
            builder.Entity<AbpStoreCouponProduct>(b => b.HasKey(t => new { t.CouponId, t.ProductId }));
            builder.Entity<AbpStoreCouponUser>();
            builder.Entity<AbpStoreOrder>();
            builder.Entity<AbpStoreOrderCartInfo>(b => b.HasKey(t => new { t.Oid, t.CartId, t.ProductId }));
            builder.Entity<AbpStoreOrderStatus>(b => b.HasKey(t => new { t.Oid, t.ChangeType }));
            builder.Entity<AbpStorePink>();
            builder.Entity<AbpStoreProduct>();
            builder.Entity<AbpStoreProductAttr>(b => b.HasKey(t => new { t.ProductId, t.AttrName, t.Type }));
            builder.Entity<AbpStoreProductAttrResult>(b => b.HasKey(t => new { t.ProductId, t.Type }));
            builder.Entity<AbpStoreProductAttrValue>(b => b.HasNoKey());
            builder.Entity<AbpStoreProductCate>();
            builder.Entity<AbpStoreProductCoupon>();
            builder.Entity<AbpStoreProductDescription>(b => b.HasKey(t => new { t.ProductId, t.Type }));
            builder.Entity<AbpStoreProductRelation>(b => b.HasKey(t => new { t.Uid, t.ProductId, t.Type, t.Category }));
            builder.Entity<AbpStoreProductReply>();
            builder.Entity<AbpStoreProductRule>();
            builder.Entity<AbpStoreSeckill>();
            builder.Entity<AbpStoreSeckillTime>(b=>b.HasNoKey());
            builder.Entity<AbpStoreService>();
            builder.Entity<AbpStoreServiceLog>();
            builder.Entity<AbpStoreVisit>();
            builder.Entity<AbpSystemAdmin>();
            builder.Entity<AbpSystemAttachment>();
            builder.Entity<AbpSystemAttachmentCategory>();
            builder.Entity<AbpSystemCity>();
            builder.Entity<AbpSystemConfig>();
            builder.Entity<AbpSystemConfigTab>();
            builder.Entity<AbpSystemFile>();
            builder.Entity<AbpSystemGroup>();
            builder.Entity<AbpSystemGroupData>();
            builder.Entity<AbpSystemLog>();
            builder.Entity<AbpSystemMenus>();
            builder.Entity<AbpSystemNotice>();
            builder.Entity<AbpSystemNoticeAdmin>();
            builder.Entity<AbpSystemRole>();
            builder.Entity<AbpSystemStore>();
            builder.Entity<AbpSystemStoreStaff>();
            builder.Entity<AbpSystemUserLevel>();
            builder.Entity<AbpSystemUserTask>();
            builder.Entity<AbpTemplateMessage>();
            builder.Entity<AbpUser>();
            builder.Entity<AbpUserAddress>();
            builder.Entity<AbpUserBill>();
            builder.Entity<AbpUserEnter>();
            builder.Entity<AbpUserExtract>();
            builder.Entity<AbpUserGroup>();
            builder.Entity<AbpUserLabel>();
            builder.Entity<AbpUserLabelRelation>(b => b.HasKey(t => new { t.Uid, t.LabelId }));
            builder.Entity<AbpUserLevel>();
            builder.Entity<AbpUserNotice>();
            builder.Entity<AbpUserNoticeSee>();
            builder.Entity<AbpUserRecharge>();
            builder.Entity<AbpUserSign>();
            builder.Entity<AbpUserTaskFinish>();
            builder.Entity<AbpUserToken>();
            builder.Entity<AbpUserVisit>();
            builder.Entity<AbpWechatKey>();
            builder.Entity<AbpWechatMedia>();
            builder.Entity<AbpWechatMessage>();
            builder.Entity<AbpWechatNewsCategory>();
            builder.Entity<AbpWechatQrcode>();
            builder.Entity<AbpWechatReply>();
            builder.Entity<AbpWechatUser>();
        }
    }
}