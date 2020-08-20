using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_order_status")]
    public partial class AbpStoreOrderStatus
    {
        [Column("oid", TypeName = "int(10) unsigned")]
        public uint Oid { get; set; }
        [Required]
        [Column("change_type", TypeName = "varchar(32)")]
        public string ChangeType { get; set; }
        [Required]
        [Column("change_message", TypeName = "varchar(256)")]
        public string ChangeMessage { get; set; }
        [Column("change_time", TypeName = "int(10) unsigned")]
        public uint ChangeTime { get; set; }
    }
}
