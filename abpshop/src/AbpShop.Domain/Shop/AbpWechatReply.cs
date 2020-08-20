using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_wechat_reply")]
    public partial class AbpWechatReply
    {
        [Key]
        [Column("id", TypeName = "mediumint(8) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("key", TypeName = "varchar(64)")]
        public string Key { get; set; }
        [Required]
        [Column("type", TypeName = "varchar(32)")]
        public string Type { get; set; }
        [Required]
        [Column("data", TypeName = "text")]
        public string Data { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte Status { get; set; }
        [Column("hide", TypeName = "tinyint(1) unsigned")]
        public byte Hide { get; set; }
    }
}
