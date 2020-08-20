using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_seckill")]
    public partial class AbpStoreSeckill
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Column("product_id", TypeName = "int(10) unsigned")]
        public uint ProductId { get; set; }
        [Required]
        [Column("image", TypeName = "varchar(255)")]
        public string Image { get; set; }
        [Required]
        [Column("images", TypeName = "varchar(2000)")]
        public string Images { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(255)")]
        public string Title { get; set; }
        [Required]
        [Column("info", TypeName = "varchar(255)")]
        public string Info { get; set; }
        [Column("price", TypeName = "decimal(10,2) unsigned")]
        public decimal Price { get; set; }
        [Column("cost", TypeName = "decimal(8,2) unsigned")]
        public decimal Cost { get; set; }
        [Column("ot_price", TypeName = "decimal(10,2) unsigned")]
        public decimal OtPrice { get; set; }
        [Column("give_integral", TypeName = "decimal(10,2) unsigned")]
        public decimal GiveIntegral { get; set; }
        [Column("sort", TypeName = "int(10) unsigned")]
        public uint Sort { get; set; }
        [Column("stock", TypeName = "int(10) unsigned")]
        public uint Stock { get; set; }
        [Column("sales", TypeName = "int(10) unsigned")]
        public uint Sales { get; set; }
        [Required]
        [Column("unit_name", TypeName = "varchar(16)")]
        public string UnitName { get; set; }
        [Column("postage", TypeName = "decimal(8,2) unsigned")]
        public decimal Postage { get; set; }
        [Column("description", TypeName = "text")]
        public string Description { get; set; }
        [Required]
        [Column("start_time", TypeName = "varchar(128)")]
        public string StartTime { get; set; }
        [Required]
        [Column("stop_time", TypeName = "varchar(128)")]
        public string StopTime { get; set; }
        [Required]
        [Column("add_time", TypeName = "varchar(128)")]
        public string AddTime { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte Status { get; set; }
        [Column("is_postage", TypeName = "tinyint(1) unsigned")]
        public byte IsPostage { get; set; }
        [Column("is_hot", TypeName = "tinyint(1) unsigned")]
        public byte IsHot { get; set; }
        [Column("is_del", TypeName = "tinyint(1) unsigned")]
        public byte IsDel { get; set; }
        [Column("num", TypeName = "int(11) unsigned")]
        public uint Num { get; set; }
        [Column("is_show", TypeName = "tinyint(1) unsigned")]
        public byte IsShow { get; set; }
        [Column("time_id", TypeName = "int(11)")]
        public int? TimeId { get; set; }
        [Column("temp_id", TypeName = "int(11)")]
        public int? TempId { get; set; }
        [Column("weight", TypeName = "decimal(8,2)")]
        public decimal? Weight { get; set; }
        [Column("volume", TypeName = "decimal(8,2)")]
        public decimal? Volume { get; set; }
        [Column("quota", TypeName = "int(10)")]
        public int Quota { get; set; }
        [Column("quota_show", TypeName = "int(10)")]
        public int QuotaShow { get; set; }
    }
}
