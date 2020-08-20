using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_order_cart_info")]
    public partial class AbpStoreOrderCartInfo
    {
        [Column("oid", TypeName = "int(11) unsigned")]
        public uint Oid { get; set; }
        [Required]
        [Column("cart_id", TypeName = "varchar(50)")]
        public string CartId { get; set; }
        [Column("product_id", TypeName = "int(10) unsigned")]
        public uint ProductId { get; set; }
        [Required]
        [Column("cart_info", TypeName = "text")]
        public string CartInfo { get; set; }
        [Required]
        [Column("unique", TypeName = "char(32)")]
        public string Unique { get; set; }
    }
}
