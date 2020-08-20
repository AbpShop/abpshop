using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_coupon_product")]
    public partial class AbpStoreCouponProduct
    {
        [Column("coupon_id", TypeName = "int(11)")]
        public int CouponId { get; set; }
        [Column("product_id", TypeName = "int(11)")]
        public int ProductId { get; set; }
    }
}
