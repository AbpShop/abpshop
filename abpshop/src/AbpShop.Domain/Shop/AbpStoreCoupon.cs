using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_coupon")]
    public partial class AbpStoreCoupon
    {
        [Key]
        [Column("id", TypeName = "int(11) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(64)")]
        public string Title { get; set; }
        [Column("integral", TypeName = "int(11) unsigned")]
        public uint Integral { get; set; }
        [Column("coupon_price", TypeName = "decimal(8,2) unsigned")]
        public decimal CouponPrice { get; set; }
        [Column("use_min_price", TypeName = "decimal(8,2) unsigned")]
        public decimal UseMinPrice { get; set; }
        [Column("coupon_time", TypeName = "int(11) unsigned")]
        public uint CouponTime { get; set; }
        [Column("sort", TypeName = "int(11) unsigned")]
        public uint Sort { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte Status { get; set; }
        [Column("add_time", TypeName = "int(11) unsigned")]
        public uint AddTime { get; set; }
        [Column("is_del", TypeName = "tinyint(1) unsigned")]
        public byte IsDel { get; set; }
        [Required]
        [Column("product_id", TypeName = "varchar(64)")]
        public string ProductId { get; set; }
        [Column("category_id", TypeName = "int(11)")]
        public int CategoryId { get; set; }
        [Column("type", TypeName = "tinyint(2)")]
        public sbyte Type { get; set; }
    }
}
