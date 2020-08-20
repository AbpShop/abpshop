using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_bargain")]
    public partial class AbpStoreBargain
    {
        [Key]
        [Column("id", TypeName = "int(11) unsigned")]
        public uint Id { get; set; }
        [Column("product_id", TypeName = "int(11) unsigned")]
        public uint ProductId { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(255)")]
        public string Title { get; set; }
        [Required]
        [Column("image", TypeName = "varchar(150)")]
        public string Image { get; set; }
        [Column("unit_name", TypeName = "varchar(16)")]
        public string UnitName { get; set; }
        [Column("stock", TypeName = "int(11) unsigned")]
        public uint? Stock { get; set; }
        [Column("sales", TypeName = "int(11) unsigned")]
        public uint? Sales { get; set; }
        [Required]
        [Column("images", TypeName = "varchar(2000)")]
        public string Images { get; set; }
        [Column("start_time", TypeName = "int(11) unsigned")]
        public uint StartTime { get; set; }
        [Column("stop_time", TypeName = "int(11) unsigned")]
        public uint StopTime { get; set; }
        [Column("store_name", TypeName = "varchar(255)")]
        public string StoreName { get; set; }
        [Column("price", TypeName = "decimal(8,2) unsigned")]
        public decimal? Price { get; set; }
        [Column("min_price", TypeName = "decimal(8,2) unsigned")]
        public decimal? MinPrice { get; set; }
        [Column("num", TypeName = "int(11) unsigned")]
        public uint? Num { get; set; }
        [Column("bargain_max_price", TypeName = "decimal(8,2) unsigned")]
        public decimal? BargainMaxPrice { get; set; }
        [Column("bargain_min_price", TypeName = "decimal(8,2) unsigned")]
        public decimal? BargainMinPrice { get; set; }
        [Column("bargain_num", TypeName = "int(11) unsigned")]
        public uint BargainNum { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte Status { get; set; }
        [Column("give_integral", TypeName = "decimal(10,2) unsigned")]
        public decimal GiveIntegral { get; set; }
        [Column("info", TypeName = "varchar(255)")]
        public string Info { get; set; }
        [Column("cost", TypeName = "decimal(8,2) unsigned")]
        public decimal? Cost { get; set; }
        [Column("sort", TypeName = "int(11) unsigned")]
        public uint Sort { get; set; }
        [Column("is_hot", TypeName = "tinyint(1) unsigned")]
        public byte IsHot { get; set; }
        [Column("is_del", TypeName = "tinyint(1) unsigned")]
        public byte IsDel { get; set; }
        [Column("add_time", TypeName = "int(11) unsigned")]
        public uint? AddTime { get; set; }
        [Column("is_postage", TypeName = "tinyint(1) unsigned")]
        public byte IsPostage { get; set; }
        [Column("postage", TypeName = "decimal(10,2) unsigned")]
        public decimal? Postage { get; set; }
        [Column("rule", TypeName = "text")]
        public string Rule { get; set; }
        [Column("look", TypeName = "int(11) unsigned")]
        public uint? Look { get; set; }
        [Column("share", TypeName = "int(11) unsigned")]
        public uint? Share { get; set; }
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
