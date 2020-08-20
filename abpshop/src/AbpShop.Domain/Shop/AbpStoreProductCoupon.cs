using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_product_coupon")]
    public partial class AbpStoreProductCoupon
    {
        [Key]
        [Column("id", TypeName = "int(10)")]
        public int Id { get; set; }
        [Column("product_id", TypeName = "int(10)")]
        public int ProductId { get; set; }
        [Column("issue_coupon_id", TypeName = "int(10)")]
        public int IssueCouponId { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(255)")]
        public string Title { get; set; }
        [Column("add_time", TypeName = "int(10)")]
        public int AddTime { get; set; }
    }
}
