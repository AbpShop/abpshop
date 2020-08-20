using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_product_attr")]
    public partial class AbpStoreProductAttr
    {
        [Column("product_id", TypeName = "int(10) unsigned")]
        public uint ProductId { get; set; }
        [Required]
        [Column("attr_name", TypeName = "varchar(32)")]
        public string AttrName { get; set; }
        [Required]
        [Column("attr_values", TypeName = "varchar(256)")]
        public string AttrValues { get; set; }
        [Column("type")]
        public bool? Type { get; set; }
    }
}
