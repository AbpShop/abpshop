using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_user_enter")]
    public partial class AbpUserEnter
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Column("uid", TypeName = "int(10) unsigned")]
        public uint Uid { get; set; }
        [Required]
        [Column("province", TypeName = "varchar(32)")]
        public string Province { get; set; }
        [Required]
        [Column("city", TypeName = "varchar(32)")]
        public string City { get; set; }
        [Required]
        [Column("district", TypeName = "varchar(32)")]
        public string District { get; set; }
        [Required]
        [Column("address", TypeName = "varchar(256)")]
        public string Address { get; set; }
        [Required]
        [Column("merchant_name", TypeName = "varchar(256)")]
        public string MerchantName { get; set; }
        [Required]
        [Column("link_user", TypeName = "varchar(32)")]
        public string LinkUser { get; set; }
        [Required]
        [Column("link_tel", TypeName = "varchar(16)")]
        public string LinkTel { get; set; }
        [Required]
        [Column("charter", TypeName = "varchar(512)")]
        public string Charter { get; set; }
        [Column("add_time", TypeName = "int(10) unsigned")]
        public uint AddTime { get; set; }
        [Column("apply_time", TypeName = "int(10) unsigned")]
        public uint ApplyTime { get; set; }
        [Column("success_time", TypeName = "int(11)")]
        public int SuccessTime { get; set; }
        [Required]
        [Column("fail_message", TypeName = "varchar(256)")]
        public string FailMessage { get; set; }
        [Column("fail_time", TypeName = "int(10) unsigned")]
        public uint FailTime { get; set; }
        [Column("status")]
        public bool Status { get; set; }
        [Column("is_lock", TypeName = "tinyint(1) unsigned")]
        public byte IsLock { get; set; }
        [Column("is_del", TypeName = "tinyint(1) unsigned")]
        public byte IsDel { get; set; }
    }
}
