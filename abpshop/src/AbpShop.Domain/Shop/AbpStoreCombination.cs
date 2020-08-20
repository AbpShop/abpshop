using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_combination")]
    public partial class AbpStoreCombination
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Column("product_id", TypeName = "int(10) unsigned")]
        public uint ProductId { get; set; }
        [Column("mer_id", TypeName = "int(10) unsigned")]
        public uint? MerId { get; set; }
        [Required]
        [Column("image", TypeName = "varchar(255)")]
        public string Image { get; set; }
        [Required]
        [Column("images", TypeName = "varchar(2000)")]
        public string Images { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(255)")]
        public string Title { get; set; }
        [Column("attr", TypeName = "varchar(255)")]
        public string Attr { get; set; }
        [Column("people", TypeName = "int(2) unsigned")]
        public uint People { get; set; }
        [Required]
        [Column("info", TypeName = "varchar(255)")]
        public string Info { get; set; }
        [Column("price", TypeName = "decimal(10,2) unsigned")]
        public decimal Price { get; set; }
        [Column("sort", TypeName = "int(10) unsigned")]
        public uint Sort { get; set; }
        [Column("sales", TypeName = "int(10) unsigned")]
        public uint Sales { get; set; }
        [Column("stock", TypeName = "int(10) unsigned")]
        public uint Stock { get; set; }
        [Required]
        [Column("add_time", TypeName = "varchar(128)")]
        public string AddTime { get; set; }
        [Column("is_host", TypeName = "tinyint(1) unsigned")]
        public byte IsHost { get; set; }
        [Column("is_show", TypeName = "tinyint(1) unsigned")]
        public byte IsShow { get; set; }
        [Column("is_del", TypeName = "tinyint(1) unsigned")]
        public byte IsDel { get; set; }
        [Column("combination", TypeName = "tinyint(1) unsigned")]
        public byte Combination { get; set; }
        [Column("mer_use", TypeName = "tinyint(1) unsigned")]
        public byte? MerUse { get; set; }
        [Column("is_postage", TypeName = "tinyint(1) unsigned")]
        public byte IsPostage { get; set; }
        [Column("postage", TypeName = "decimal(10,2) unsigned")]
        public decimal Postage { get; set; }
        [Column("start_time", TypeName = "int(11) unsigned")]
        public uint StartTime { get; set; }
        [Column("stop_time", TypeName = "int(11) unsigned")]
        public uint StopTime { get; set; }
        [Column("effective_time", TypeName = "int(11)")]
        public int EffectiveTime { get; set; }
        [Column("cost", TypeName = "int(10) unsigned")]
        public uint Cost { get; set; }
        [Column("browse", TypeName = "int(11)")]
        public int? Browse { get; set; }
        [Required]
        [Column("unit_name", TypeName = "varchar(32)")]
        public string UnitName { get; set; }
        [Column("temp_id", TypeName = "int(11)")]
        public int? TempId { get; set; }
        [Column("weight", TypeName = "decimal(8,2)")]
        public decimal? Weight { get; set; }
        [Column("volume", TypeName = "decimal(8,2)")]
        public decimal? Volume { get; set; }
        [Column("num", TypeName = "int(11)")]
        public int? Num { get; set; }
        [Column("quota", TypeName = "int(10)")]
        public int Quota { get; set; }
        [Column("quota_show", TypeName = "int(10)")]
        public int QuotaShow { get; set; }
    }
}
