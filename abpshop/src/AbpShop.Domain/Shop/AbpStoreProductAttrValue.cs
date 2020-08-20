using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_product_attr_value")]
    public partial class AbpStoreProductAttrValue
    {
        [Column("product_id", TypeName = "int(10) unsigned")]
        public uint ProductId { get; set; }
        [Required]
        [Column("suk", TypeName = "varchar(128)")]
        public string Suk { get; set; }
        [Column("stock", TypeName = "int(10) unsigned")]
        public uint Stock { get; set; }
        [Column("sales", TypeName = "int(10) unsigned")]
        public uint Sales { get; set; }
        [Column("price", TypeName = "decimal(8,2) unsigned")]
        public decimal Price { get; set; }
        [Column("image", TypeName = "varchar(128)")]
        public string Image { get; set; }
        [Required]
        [Column("unique", TypeName = "char(8)")]
        public string Unique { get; set; }
        [Column("cost", TypeName = "decimal(8,2) unsigned")]
        public decimal Cost { get; set; }
        [Required]
        [Column("bar_code", TypeName = "varchar(50)")]
        public string BarCode { get; set; }
        [Column("ot_price", TypeName = "decimal(8,2)")]
        public decimal OtPrice { get; set; }
        [Column("weight", TypeName = "decimal(8,2)")]
        public decimal Weight { get; set; }
        [Column("volume", TypeName = "decimal(8,2)")]
        public decimal Volume { get; set; }
        [Column("brokerage", TypeName = "decimal(8,2)")]
        public decimal Brokerage { get; set; }
        [Column("brokerage_two", TypeName = "decimal(8,2)")]
        public decimal BrokerageTwo { get; set; }
        [Column("type")]
        public bool? Type { get; set; }
        [Column("quota", TypeName = "int(11)")]
        public int? Quota { get; set; }
        [Column("quota_show", TypeName = "int(11)")]
        public int? QuotaShow { get; set; }
    }
}
