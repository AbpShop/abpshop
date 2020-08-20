using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_article")]
    public partial class AbpArticle
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Column("cid", TypeName = "varchar(255)")]
        public string Cid { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(255)")]
        public string Title { get; set; }
        [Column("author", TypeName = "varchar(255)")]
        public string Author { get; set; }
        [Required]
        [Column("image_input", TypeName = "varchar(255)")]
        public string ImageInput { get; set; }
        [Column("synopsis", TypeName = "varchar(255)")]
        public string Synopsis { get; set; }
        [Column("share_title", TypeName = "varchar(255)")]
        public string ShareTitle { get; set; }
        [Column("share_synopsis", TypeName = "varchar(255)")]
        public string ShareSynopsis { get; set; }
        [Column("visit", TypeName = "varchar(255)")]
        public string Visit { get; set; }
        [Column("sort", TypeName = "int(10) unsigned")]
        public uint Sort { get; set; }
        [Column("url", TypeName = "varchar(255)")]
        public string Url { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte Status { get; set; }
        [Required]
        [Column("add_time", TypeName = "varchar(255)")]
        public string AddTime { get; set; }
        [Column("hide", TypeName = "tinyint(1) unsigned")]
        public byte Hide { get; set; }
        [Column("admin_id", TypeName = "int(10) unsigned")]
        public uint AdminId { get; set; }
        [Column("mer_id", TypeName = "int(10) unsigned")]
        public uint? MerId { get; set; }
        [Column("product_id", TypeName = "int(10)")]
        public int ProductId { get; set; }
        [Column("is_hot", TypeName = "tinyint(1) unsigned")]
        public byte IsHot { get; set; }
        [Column("is_banner", TypeName = "tinyint(1) unsigned")]
        public byte IsBanner { get; set; }
    }
}
