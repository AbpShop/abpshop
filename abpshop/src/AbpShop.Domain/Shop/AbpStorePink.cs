using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_pink")]
    public partial class AbpStorePink
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Column("uid", TypeName = "int(10) unsigned")]
        public uint Uid { get; set; }
        [Required]
        [Column("order_id", TypeName = "varchar(32)")]
        public string OrderId { get; set; }
        [Column("order_id_key", TypeName = "int(10) unsigned")]
        public uint OrderIdKey { get; set; }
        [Column("total_num", TypeName = "int(10) unsigned")]
        public uint TotalNum { get; set; }
        [Column("total_price", TypeName = "decimal(10,2) unsigned")]
        public decimal TotalPrice { get; set; }
        [Column("cid", TypeName = "int(10) unsigned")]
        public uint Cid { get; set; }
        [Column("pid", TypeName = "int(10) unsigned")]
        public uint Pid { get; set; }
        [Column("people", TypeName = "int(10) unsigned")]
        public uint People { get; set; }
        [Column("price", TypeName = "decimal(10,2) unsigned")]
        public decimal Price { get; set; }
        [Required]
        [Column("add_time", TypeName = "varchar(24)")]
        public string AddTime { get; set; }
        [Required]
        [Column("stop_time", TypeName = "varchar(24)")]
        public string StopTime { get; set; }
        [Column("k_id", TypeName = "int(10) unsigned")]
        public uint KId { get; set; }
        [Column("is_tpl", TypeName = "tinyint(1) unsigned")]
        public byte IsTpl { get; set; }
        [Column("is_refund", TypeName = "tinyint(1) unsigned")]
        public byte IsRefund { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte Status { get; set; }
    }
}
