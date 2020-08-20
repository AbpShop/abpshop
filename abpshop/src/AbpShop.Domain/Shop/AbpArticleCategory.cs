using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_article_category")]
    public partial class AbpArticleCategory
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Column("pid", TypeName = "int(11)")]
        public int Pid { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(255)")]
        public string Title { get; set; }
        [Column("intr", TypeName = "varchar(255)")]
        public string Intr { get; set; }
        [Required]
        [Column("image", TypeName = "varchar(255)")]
        public string Image { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte Status { get; set; }
        [Column("sort", TypeName = "int(10) unsigned")]
        public uint Sort { get; set; }
        [Column("is_del", TypeName = "tinyint(1) unsigned")]
        public byte IsDel { get; set; }
        [Required]
        [Column("add_time", TypeName = "varchar(255)")]
        public string AddTime { get; set; }
        [Column("hidden", TypeName = "tinyint(1) unsigned")]
        public byte Hidden { get; set; }
    }
}
