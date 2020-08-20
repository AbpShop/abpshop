using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_wechat_media")]
    public partial class AbpWechatMedia
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("type", TypeName = "varchar(16)")]
        public string Type { get; set; }
        [Required]
        [Column("path", TypeName = "varchar(128)")]
        public string Path { get; set; }
        [Required]
        [Column("media_id", TypeName = "varchar(64)")]
        public string MediaId { get; set; }
        [Required]
        [Column("url", TypeName = "varchar(256)")]
        public string Url { get; set; }
        [Column("temporary", TypeName = "tinyint(1) unsigned")]
        public byte Temporary { get; set; }
        [Column("add_time", TypeName = "int(10) unsigned")]
        public uint AddTime { get; set; }
    }
}
