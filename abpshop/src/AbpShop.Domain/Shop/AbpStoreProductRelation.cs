using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_product_relation")]
    public partial class AbpStoreProductRelation
    {
        [Column("uid", TypeName = "int(10) unsigned")]
        public uint Uid { get; set; }
        [Column("product_id", TypeName = "int(10) unsigned")]
        public uint ProductId { get; set; }
        [Required]
        [Column("type", TypeName = "varchar(32)")]
        public string Type { get; set; }
        [Required]
        [Column("category", TypeName = "varchar(32)")]
        public string Category { get; set; }
        [Column("add_time", TypeName = "int(10) unsigned")]
        public uint AddTime { get; set; }
    }
}
