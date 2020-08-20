using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_admin")]
    public partial class AbpSystemAdmin
    {
        [Key]
        [Column("id", TypeName = "smallint(5) unsigned")]
        public ushort Id { get; set; }
        [Required]
        [Column("account", TypeName = "varchar(32)")]
        public string Account { get; set; }
        [Required]
        [Column("head_pic", TypeName = "varchar(255)")]
        public string HeadPic { get; set; }
        [Required]
        [Column("pwd", TypeName = "char(100)")]
        public string Pwd { get; set; }
        [Required]
        [Column("real_name", TypeName = "varchar(16)")]
        public string RealName { get; set; }
        [Required]
        [Column("roles", TypeName = "varchar(128)")]
        public string Roles { get; set; }
        [Column("last_ip", TypeName = "varchar(16)")]
        public string LastIp { get; set; }
        [Column("last_time", TypeName = "int(10) unsigned")]
        public uint? LastTime { get; set; }
        [Column("add_time", TypeName = "int(10) unsigned")]
        public uint AddTime { get; set; }
        [Column("login_count", TypeName = "int(10) unsigned")]
        public uint LoginCount { get; set; }
        [Column("level", TypeName = "tinyint(3) unsigned")]
        public byte Level { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte Status { get; set; }
        [Column("is_del", TypeName = "tinyint(1) unsigned")]
        public byte IsDel { get; set; }
    }
}
