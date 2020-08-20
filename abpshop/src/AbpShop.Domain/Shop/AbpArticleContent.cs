using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_article_content")]
    public partial class AbpArticleContent
    {
        [Key]
        [Column("nid", TypeName = "int(10) unsigned")]
        public uint Nid { get; set; }
        [Required]
        [Column("content", TypeName = "text")]
        public string Content { get; set; }
    }
}
