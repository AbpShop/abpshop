using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_coupon_user")]
    public partial class AbpStoreCouponUser
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("cid", TypeName = "int(11) unsigned")]
        public uint Cid { get; set; }
        [Column("uid", TypeName = "int(11) unsigned")]
        public uint Uid { get; set; }
        [Required]
        [Column("coupon_title", TypeName = "varchar(32)")]
        public string CouponTitle { get; set; }
        [Column("coupon_price", TypeName = "decimal(8,2) unsigned")]
        public decimal CouponPrice { get; set; }
        [Column("use_min_price", TypeName = "decimal(8,2) unsigned")]
        public decimal UseMinPrice { get; set; }
        [Column("add_time", TypeName = "int(11) unsigned")]
        public uint AddTime { get; set; }
        [Column("end_time", TypeName = "int(11) unsigned")]
        public uint EndTime { get; set; }
        [Column("use_time", TypeName = "int(11) unsigned")]
        public uint UseTime { get; set; }
        [Required]
        [Column("type", TypeName = "varchar(32)")]
        public string Type { get; set; }
        [Column("status")]
        public bool Status { get; set; }
        [Column("is_fail", TypeName = "tinyint(1) unsigned")]
        public byte IsFail { get; set; }
    }
}
