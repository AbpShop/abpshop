using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_wechat_qrcode")]
    public partial class AbpWechatQrcode
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("third_type", TypeName = "varchar(32)")]
        public string ThirdType { get; set; }
        [Column("third_id", TypeName = "int(11) unsigned")]
        public uint ThirdId { get; set; }
        [Required]
        [Column("ticket", TypeName = "varchar(255)")]
        public string Ticket { get; set; }
        [Column("expire_seconds", TypeName = "int(10) unsigned")]
        public uint ExpireSeconds { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte Status { get; set; }
        [Required]
        [Column("add_time", TypeName = "varchar(255)")]
        public string AddTime { get; set; }
        [Required]
        [Column("url", TypeName = "varchar(255)")]
        public string Url { get; set; }
        [Required]
        [Column("qrcode_url", TypeName = "varchar(255)")]
        public string QrcodeUrl { get; set; }
        [Column("scan", TypeName = "int(10) unsigned")]
        public uint Scan { get; set; }
    }
}
