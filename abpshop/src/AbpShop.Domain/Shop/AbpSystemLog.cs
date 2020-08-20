using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_log")]
    public partial class AbpSystemLog
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Column("admin_id", TypeName = "int(10) unsigned")]
        public uint AdminId { get; set; }
        [Required]
        [Column("admin_name", TypeName = "varchar(64)")]
        public string AdminName { get; set; }
        [Required]
        [Column("path", TypeName = "varchar(128)")]
        public string Path { get; set; }
        [Required]
        [Column("page", TypeName = "varchar(64)")]
        public string Page { get; set; }
        [Required]
        [Column("method", TypeName = "varchar(12)")]
        public string Method { get; set; }
        [Required]
        [Column("ip", TypeName = "varchar(16)")]
        public string Ip { get; set; }
        [Required]
        [Column("type", TypeName = "varchar(32)")]
        public string Type { get; set; }
        [Column("add_time", TypeName = "int(10) unsigned")]
        public uint AddTime { get; set; }
        [Column("merchant_id", TypeName = "int(10) unsigned")]
        public uint MerchantId { get; set; }
    }
}
