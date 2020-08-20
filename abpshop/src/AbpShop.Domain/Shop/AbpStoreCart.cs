using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_cart")]
    public partial class AbpStoreCart
    {
        [Key]
        [Column("id", TypeName = "bigint(8) unsigned")]
        public ulong Id { get; set; }
        [Column("uid", TypeName = "int(10) unsigned")]
        public uint Uid { get; set; }
        [Required]
        [Column("type", TypeName = "varchar(32)")]
        public string Type { get; set; }
        [Column("product_id", TypeName = "int(10) unsigned")]
        public uint ProductId { get; set; }
        [Required]
        [Column("product_attr_unique", TypeName = "varchar(16)")]
        public string ProductAttrUnique { get; set; }
        [Column("cart_num", TypeName = "smallint(5) unsigned")]
        public ushort CartNum { get; set; }
        [Column("add_time", TypeName = "int(10) unsigned")]
        public uint AddTime { get; set; }
        [Column("is_pay")]
        public bool IsPay { get; set; }
        [Column("is_del")]
        public bool IsDel { get; set; }
        [Column("is_new")]
        public bool IsNew { get; set; }
        [Column("combination_id", TypeName = "int(11) unsigned")]
        public uint? CombinationId { get; set; }
        [Column("seckill_id", TypeName = "int(10) unsigned")]
        public uint SeckillId { get; set; }
        [Column("bargain_id", TypeName = "int(11) unsigned")]
        public uint BargainId { get; set; }
        [Required]
        [Column("status")]
        public bool? Status { get; set; }
    }
}
