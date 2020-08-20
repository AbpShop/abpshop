using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_product_description")]
    public partial class AbpStoreProductDescription
    {
        [Column("product_id", TypeName = "int(11)")]
        public int ProductId { get; set; }
        [Required]
        [Column("description", TypeName = "text")]
        public string Description { get; set; }
        [Column("type")]
        public bool Type { get; set; }
    }
}
