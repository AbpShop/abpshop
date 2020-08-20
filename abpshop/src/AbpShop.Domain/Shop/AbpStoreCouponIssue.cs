using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_coupon_issue")]
    public partial class AbpStoreCouponIssue
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Column("cid", TypeName = "int(10)")]
        public int? Cid { get; set; }
        [Column("coupon_title", TypeName = "varchar(255)")]
        public string CouponTitle { get; set; }
        [Column("start_time", TypeName = "int(10)")]
        public int? StartTime { get; set; }
        [Column("end_time", TypeName = "int(10)")]
        public int? EndTime { get; set; }
        [Column("total_count", TypeName = "int(10)")]
        public int? TotalCount { get; set; }
        [Column("remain_count", TypeName = "int(10)")]
        public int? RemainCount { get; set; }
        [Column("is_permanent")]
        public bool IsPermanent { get; set; }
        [Required]
        [Column("status")]
        public bool? Status { get; set; }
        [Column("is_give_subscribe")]
        public bool IsGiveSubscribe { get; set; }
        [Column("is_full_give")]
        public bool IsFullGive { get; set; }
        [Column("full_reduction", TypeName = "decimal(8,2)")]
        public decimal FullReduction { get; set; }
        [Column("is_del", TypeName = "tinyint(1) unsigned")]
        public byte IsDel { get; set; }
        [Column("add_time", TypeName = "int(10)")]
        public int? AddTime { get; set; }
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
        [Required]
        [Column("product_id", TypeName = "varchar(64)")]
        public string ProductId { get; set; }
        [Column("category_id", TypeName = "int(11)")]
        public int CategoryId { get; set; }
        [Column("type", TypeName = "tinyint(2)")]
        public sbyte Type { get; set; }
    }
}
