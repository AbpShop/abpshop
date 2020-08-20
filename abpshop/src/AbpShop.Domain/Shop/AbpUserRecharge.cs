using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_user_recharge")]
    public partial class AbpUserRecharge
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Column("uid", TypeName = "int(10)")]
        public int? Uid { get; set; }
        [Column("order_id", TypeName = "varchar(32)")]
        public string OrderId { get; set; }
        [Column("price", TypeName = "decimal(8,2)")]
        public decimal? Price { get; set; }
        [Column("give_price", TypeName = "decimal(8,2)")]
        public decimal GivePrice { get; set; }
        [Column("recharge_type", TypeName = "varchar(32)")]
        public string RechargeType { get; set; }
        [Column("paid")]
        public bool? Paid { get; set; }
        [Column("pay_time", TypeName = "int(10)")]
        public int? PayTime { get; set; }
        [Column("add_time", TypeName = "int(12)")]
        public int? AddTime { get; set; }
        [Column("refund_price", TypeName = "decimal(10,2)")]
        public decimal? RefundPrice { get; set; }
    }
}
