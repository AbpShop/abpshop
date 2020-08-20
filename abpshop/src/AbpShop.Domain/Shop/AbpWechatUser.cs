using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_wechat_user")]
    public partial class AbpWechatUser
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("uid", TypeName = "int(10) unsigned")]
        public uint Uid { get; set; }
        [Column("unionid", TypeName = "varchar(30)")]
        public string Unionid { get; set; }
        [Column("openid", TypeName = "varchar(30)")]
        public string Openid { get; set; }
        [Required]
        [Column("nickname", TypeName = "varchar(64)")]
        public string Nickname { get; set; }
        [Required]
        [Column("headimgurl", TypeName = "varchar(256)")]
        public string Headimgurl { get; set; }
        [Column("sex", TypeName = "tinyint(1) unsigned")]
        public byte Sex { get; set; }
        [Required]
        [Column("city", TypeName = "varchar(64)")]
        public string City { get; set; }
        [Required]
        [Column("language", TypeName = "varchar(64)")]
        public string Language { get; set; }
        [Required]
        [Column("province", TypeName = "varchar(64)")]
        public string Province { get; set; }
        [Required]
        [Column("country", TypeName = "varchar(64)")]
        public string Country { get; set; }
        [Column("remark", TypeName = "varchar(256)")]
        public string Remark { get; set; }
        [Column("groupid", TypeName = "smallint(5) unsigned")]
        public ushort? Groupid { get; set; }
        [Column("tagid_list", TypeName = "varchar(256)")]
        public string TagidList { get; set; }
        [Column("subscribe", TypeName = "tinyint(3) unsigned")]
        public byte? Subscribe { get; set; }
        [Column("subscribe_time", TypeName = "int(10) unsigned")]
        public uint? SubscribeTime { get; set; }
        [Column("add_time", TypeName = "int(10) unsigned")]
        public uint? AddTime { get; set; }
        [Column("user_type", TypeName = "varchar(32)")]
        public string UserType { get; set; }
        [Column("is_complete")]
        public bool IsComplete { get; set; }
    }
}
