using Microsoft.EntityFrameworkCore;
using AbpShop.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;
using AbpShop.Merchant;

namespace AbpShop.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See AbpShopMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class AbpShopDbContext : AbpDbContext<AbpShopDbContext>
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Community> Community { get; set; }
        #region Shop db
        public DbSet<AbpArticle> AbpArticle { get; set; }
        public DbSet<AbpArticleCategory> AbpArticleCategory { get; set; }
        public DbSet<AbpArticleContent> AbpArticleContent { get; set; }
        public DbSet<AbpCache> AbpCache { get; set; }
        public DbSet<AbpDiy> AbpDiy { get; set; }
        public DbSet<AbpExpress> AbpExpress { get; set; }
        public DbSet<AbpQrcode> AbpQrcode { get; set; }
        public DbSet<AbpRoutineAccessToken> AbpRoutineAccessToken { get; set; }
        public DbSet<AbpRoutineFormId> AbpRoutineFormId { get; set; }
        public DbSet<AbpRoutineQrcode> AbpRoutineQrcode { get; set; }
        public DbSet<AbpShippingTemplates> AbpShippingTemplates { get; set; }
        public DbSet<AbpShippingTemplatesFree> AbpShippingTemplatesFree { get; set; }
        public DbSet<AbpShippingTemplatesRegion> AbpShippingTemplatesRegion { get; set; }
        public DbSet<AbpSmsRecord> AbpSmsRecord { get; set; }
        public DbSet<AbpStoreBargain> AbpStoreBargain { get; set; }
        public DbSet<AbpStoreBargainUser> AbpStoreBargainUser { get; set; }
        public DbSet<AbpStoreBargainUserHelp> AbpStoreBargainUserHelp { get; set; }
        public DbSet<AbpStoreCart> AbpStoreCart { get; set; }
        public DbSet<AbpStoreCategory> AbpStoreCategory { get; set; }
        public DbSet<AbpStoreCombination> AbpStoreCombination { get; set; }
        public DbSet<AbpStoreCoupon> AbpStoreCoupon { get; set; }
        public DbSet<AbpStoreCouponIssue> AbpStoreCouponIssue { get; set; }
        public DbSet<AbpStoreCouponIssueUser> AbpStoreCouponIssueUser { get; set; }
        public DbSet<AbpStoreCouponProduct> AbpStoreCouponProduct { get; set; }
        public DbSet<AbpStoreCouponUser> AbpStoreCouponUser { get; set; }
        public DbSet<AbpStoreOrder> AbpStoreOrder { get; set; }
        public DbSet<AbpStoreOrderCartInfo> AbpStoreOrderCartInfo { get; set; }
        public DbSet<AbpStoreOrderStatus> AbpStoreOrderStatus { get; set; }
        public DbSet<AbpStorePink> AbpStorePink { get; set; }
        public DbSet<AbpStoreProduct> AbpStoreProduct { get; set; }
        public DbSet<AbpStoreProductAttr> AbpStoreProductAttr { get; set; }
        public DbSet<AbpStoreProductAttrResult> AbpStoreProductAttrResult { get; set; }
        public DbSet<AbpStoreProductAttrValue> AbpStoreProductAttrValue { get; set; }
        public DbSet<AbpStoreProductCate> AbpStoreProductCate { get; set; }
        public DbSet<AbpStoreProductCoupon> AbpStoreProductCoupon { get; set; }
        public DbSet<AbpStoreProductDescription> AbpStoreProductDescription { get; set; }
        public DbSet<AbpStoreProductRelation> AbpStoreProductRelation { get; set; }
        public DbSet<AbpStoreProductReply> AbpStoreProductReply { get; set; }
        public DbSet<AbpStoreProductRule> AbpStoreProductRule { get; set; }
        public DbSet<AbpStoreSeckill> AbpStoreSeckill { get; set; }
        public DbSet<AbpStoreSeckillTime> AbpStoreSeckillTime { get; set; }
        public DbSet<AbpStoreService> AbpStoreService { get; set; }
        public DbSet<AbpStoreServiceLog> AbpStoreServiceLog { get; set; }
        public DbSet<AbpStoreVisit> AbpStoreVisit { get; set; }
        public DbSet<AbpSystemAdmin> AbpSystemAdmin { get; set; }
        public DbSet<AbpSystemAttachment> AbpSystemAttachment { get; set; }
        public DbSet<AbpSystemAttachmentCategory> AbpSystemAttachmentCategory { get; set; }
        public DbSet<AbpSystemCity> AbpSystemCity { get; set; }
        public DbSet<AbpSystemConfig> AbpSystemConfig { get; set; }
        public DbSet<AbpSystemConfigTab> AbpSystemConfigTab { get; set; }
        public DbSet<AbpSystemFile> AbpSystemFile { get; set; }
        public DbSet<AbpSystemGroup> AbpSystemGroup { get; set; }
        public DbSet<AbpSystemGroupData> AbpSystemGroupData { get; set; }
        public DbSet<AbpSystemLog> AbpSystemLog { get; set; }
        public DbSet<AbpSystemMenus> AbpSystemMenus { get; set; }
        public DbSet<AbpSystemNotice> AbpSystemNotice { get; set; }
        public DbSet<AbpSystemNoticeAdmin> AbpSystemNoticeAdmin { get; set; }
        public DbSet<AbpSystemRole> AbpSystemRole { get; set; }
        public DbSet<AbpSystemStore> AbpSystemStore { get; set; }
        public DbSet<AbpSystemStoreStaff> AbpSystemStoreStaff { get; set; }
        public DbSet<AbpSystemUserLevel> AbpSystemUserLevel { get; set; }
        public DbSet<AbpSystemUserTask> AbpSystemUserTask { get; set; }
        public DbSet<AbpTemplateMessage> AbpTemplateMessage { get; set; }
        public DbSet<AbpUser> AbpUser { get; set; }
        public DbSet<AbpUserAddress> AbpUserAddress { get; set; }
        public DbSet<AbpUserBill> AbpUserBill { get; set; }
        public DbSet<AbpUserEnter> AbpUserEnter { get; set; }
        public DbSet<AbpUserExtract> AbpUserExtract { get; set; }
        public DbSet<AbpUserGroup> AbpUserGroup { get; set; }
        public DbSet<AbpUserLabel> AbpUserLabel { get; set; }
        public DbSet<AbpUserLabelRelation> AbpUserLabelRelation { get; set; }
        public DbSet<AbpUserLevel> AbpUserLevel { get; set; }
        public DbSet<AbpUserNotice> AbpUserNotice { get; set; }
        public DbSet<AbpUserNoticeSee> AbpUserNoticeSee { get; set; }
        public DbSet<AbpUserRecharge> AbpUserRecharge { get; set; }
        public DbSet<AbpUserSign> AbpUserSign { get; set; }
        public DbSet<AbpUserTaskFinish> AbpUserTaskFinish { get; set; }
        public DbSet<AbpUserToken> AbpUserToken { get; set; }
        public DbSet<AbpUserVisit> AbpUserVisit { get; set; }
        public DbSet<AbpWechatKey> AbpWechatKey { get; set; }
        public DbSet<AbpWechatMedia> AbpWechatMedia { get; set; }
        public DbSet<AbpWechatMessage> AbpWechatMessage { get; set; }
        public DbSet<AbpWechatNewsCategory> AbpWechatNewsCategory { get; set; }
        public DbSet<AbpWechatQrcode> AbpWechatQrcode { get; set; }
        public DbSet<AbpWechatReply> AbpWechatReply { get; set; }
        public DbSet<AbpWechatUser> AbpWechatUser { get; set; }
        #endregion
        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside AbpShopDbContextModelCreatingExtensions.ConfigureAbpShop
         */

        public AbpShopDbContext(DbContextOptions<AbpShopDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */
            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser
                
                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                /* Configure mappings for your additional properties
                 * Also see the AbpShopEfCoreEntityExtensionMappings class
                 */
            });
            /* Configure your own tables/entities inside the ConfigureAbpShop method */

            builder.ConfigureAbpShop();
        }
    }
}
