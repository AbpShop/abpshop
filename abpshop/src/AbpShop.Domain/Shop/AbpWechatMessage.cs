using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_wechat_message")]
    public partial class AbpWechatMessage
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("openid", TypeName = "varchar(32)")]
        public string Openid { get; set; }
        [Required]
        [Column("type", TypeName = "varchar(32)")]
        public string Type { get; set; }
        [Required]
        [Column("result", TypeName = "varchar(512)")]
        public string Result { get; set; }
        [Column("add_time", TypeName = "int(10) unsigned")]
        public uint AddTime { get; set; }
    }
}
