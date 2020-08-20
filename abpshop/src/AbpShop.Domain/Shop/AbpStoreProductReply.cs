using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_product_reply")]
    public partial class AbpStoreProductReply
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("uid", TypeName = "int(11)")]
        public int Uid { get; set; }
        [Column("oid", TypeName = "int(11)")]
        public int Oid { get; set; }
        [Required]
        [Column("unique", TypeName = "char(32)")]
        public string Unique { get; set; }
        [Column("product_id", TypeName = "int(11)")]
        public int ProductId { get; set; }
        [Required]
        [Column("reply_type", TypeName = "varchar(32)")]
        public string ReplyType { get; set; }
        [Column("product_score")]
        public bool ProductScore { get; set; }
        [Column("service_score")]
        public bool ServiceScore { get; set; }
        [Required]
        [Column("comment", TypeName = "varchar(512)")]
        public string Comment { get; set; }
        [Required]
        [Column("pics", TypeName = "text")]
        public string Pics { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int AddTime { get; set; }
        [Column("merchant_reply_content", TypeName = "varchar(300)")]
        public string MerchantReplyContent { get; set; }
        [Column("merchant_reply_time", TypeName = "int(11)")]
        public int? MerchantReplyTime { get; set; }
        [Column("is_del", TypeName = "tinyint(1) unsigned")]
        public byte IsDel { get; set; }
        [Column("is_reply")]
        public bool IsReply { get; set; }
        [Required]
        [Column("nickname", TypeName = "varchar(64)")]
        public string Nickname { get; set; }
        [Required]
        [Column("avatar", TypeName = "varchar(255)")]
        public string Avatar { get; set; }
    }
}
