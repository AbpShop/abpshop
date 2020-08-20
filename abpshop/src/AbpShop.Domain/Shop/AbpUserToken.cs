using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_user_token")]
    public partial class AbpUserToken
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("uid", TypeName = "int(10) unsigned")]
        public uint Uid { get; set; }
        [Required]
        [Column("token", TypeName = "varchar(500)")]
        public string Token { get; set; }
        [Column("create_time", TypeName = "datetime")]
        public DateTime CreateTime { get; set; }
        [Column("expires_time", TypeName = "datetime")]
        public DateTime ExpiresTime { get; set; }
        [Column("login_ip", TypeName = "varchar(32)")]
        public string LoginIp { get; set; }
    }
}
