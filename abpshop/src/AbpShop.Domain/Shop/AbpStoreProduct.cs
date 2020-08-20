using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_product")]
    public partial class AbpStoreProduct
    {
        [Key]
        [Column("id", TypeName = "mediumint(11)")]
        public int Id { get; set; }
        [Column("mer_id", TypeName = "int(10) unsigned")]
        public uint MerId { get; set; }
        [Required]
        [Column("image", TypeName = "varchar(256)")]
        public string Image { get; set; }
        [Required]
        [Column("slider_image", TypeName = "varchar(2000)")]
        public string SliderImage { get; set; }
        [Required]
        [Column("store_name", TypeName = "varchar(128)")]
        public string StoreName { get; set; }
        [Required]
        [Column("store_info", TypeName = "varchar(256)")]
        public string StoreInfo { get; set; }
        [Required]
        [Column("keyword", TypeName = "varchar(256)")]
        public string Keyword { get; set; }
        [Required]
        [Column("bar_code", TypeName = "varchar(15)")]
        public string BarCode { get; set; }
        [Required]
        [Column("cate_id", TypeName = "varchar(64)")]
        public string CateId { get; set; }
        [Column("price", TypeName = "decimal(8,2) unsigned")]
        public decimal Price { get; set; }
        [Column("vip_price", TypeName = "decimal(8,2) unsigned")]
        public decimal VipPrice { get; set; }
        [Column("ot_price", TypeName = "decimal(8,2) unsigned")]
        public decimal OtPrice { get; set; }
        [Column("postage", TypeName = "decimal(8,2) unsigned")]
        public decimal Postage { get; set; }
        [Required]
        [Column("unit_name", TypeName = "varchar(32)")]
        public string UnitName { get; set; }
        [Column("sort", TypeName = "smallint(11)")]
        public short Sort { get; set; }
        [Column("sales", TypeName = "mediumint(11) unsigned")]
        public uint Sales { get; set; }
        [Column("stock", TypeName = "mediumint(11) unsigned")]
        public uint Stock { get; set; }
        [Required]
        [Column("is_show")]
        public bool? IsShow { get; set; }
        [Column("is_hot")]
        public bool IsHot { get; set; }
        [Column("is_benefit")]
        public bool IsBenefit { get; set; }
        [Column("is_best")]
        public bool IsBest { get; set; }
        [Column("is_new")]
        public bool IsNew { get; set; }
        [Column("add_time", TypeName = "int(11) unsigned")]
        public uint AddTime { get; set; }
        [Column("is_postage", TypeName = "tinyint(1) unsigned")]
        public byte IsPostage { get; set; }
        [Column("is_del", TypeName = "tinyint(1) unsigned")]
        public byte IsDel { get; set; }
        [Column("mer_use", TypeName = "tinyint(1) unsigned")]
        public byte MerUse { get; set; }
        [Column("give_integral", TypeName = "decimal(8,2) unsigned")]
        public decimal GiveIntegral { get; set; }
        [Column("cost", TypeName = "decimal(8,2) unsigned")]
        public decimal Cost { get; set; }
        [Column("is_seckill", TypeName = "tinyint(1) unsigned")]
        public byte IsSeckill { get; set; }
        [Column("is_bargain", TypeName = "tinyint(1) unsigned")]
        public byte? IsBargain { get; set; }
        [Column("is_good")]
        public bool IsGood { get; set; }
        [Column("is_sub")]
        public bool IsSub { get; set; }
        [Column("ficti", TypeName = "mediumint(11)")]
        public int? Ficti { get; set; }
        [Column("browse", TypeName = "int(11)")]
        public int? Browse { get; set; }
        [Required]
        [Column("code_path", TypeName = "varchar(64)")]
        public string CodePath { get; set; }
        [Column("soure_link", TypeName = "varchar(255)")]
        public string SoureLink { get; set; }
        [Required]
        [Column("video_link", TypeName = "varchar(200)")]
        public string VideoLink { get; set; }
        [Column("temp_id", TypeName = "int(11)")]
        public int TempId { get; set; }
        [Column("spec_type")]
        public bool SpecType { get; set; }
        [Required]
        [Column("activity", TypeName = "varchar(255)")]
        public string Activity { get; set; }
        [Required]
        [Column("spu", TypeName = "char(13)")]
        public string Spu { get; set; }
        [Required]
        [Column("label_id", TypeName = "varchar(64)")]
        public string LabelId { get; set; }
    }
}
