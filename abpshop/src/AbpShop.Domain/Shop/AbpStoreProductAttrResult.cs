using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_product_attr_result")]
    public partial class AbpStoreProductAttrResult
    {
        [Column("product_id", TypeName = "int(10) unsigned")]
        public uint ProductId { get; set; }
        [Required]
        [Column("result", TypeName = "text")]
        public string Result { get; set; }
        [Column("change_time", TypeName = "int(10) unsigned")]
        public uint ChangeTime { get; set; }
        [Column("type")]
        public bool? Type { get; set; }
    }
}
