using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_user_notice")]
    public partial class AbpUserNotice
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("uid", TypeName = "text")]
        public string Uid { get; set; }
        [Required]
        [Column("type")]
        public bool? Type { get; set; }
        [Required]
        [Column("user", TypeName = "varchar(20)")]
        public string User { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(20)")]
        public string Title { get; set; }
        [Required]
        [Column("content", TypeName = "varchar(500)")]
        public string Content { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int AddTime { get; set; }
        [Column("is_send")]
        public bool IsSend { get; set; }
        [Column("send_time", TypeName = "int(11)")]
        public int SendTime { get; set; }
    }
}
