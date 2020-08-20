using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_wechat_key")]
    public partial class AbpWechatKey
    {
        [Key]
        [Column("id", TypeName = "int(10)")]
        public int Id { get; set; }
        [Column("reply_id", TypeName = "int(10)")]
        public int ReplyId { get; set; }
        [Required]
        [Column("keys", TypeName = "varchar(64)")]
        public string Keys { get; set; }
    }
}
