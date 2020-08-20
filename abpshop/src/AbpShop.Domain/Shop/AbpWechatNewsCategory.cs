using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_wechat_news_category")]
    public partial class AbpWechatNewsCategory
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("cate_name", TypeName = "varchar(255)")]
        public string CateName { get; set; }
        [Column("sort", TypeName = "int(10) unsigned")]
        public uint Sort { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte Status { get; set; }
        [Required]
        [Column("new_id", TypeName = "varchar(255)")]
        public string NewId { get; set; }
        [Required]
        [Column("add_time", TypeName = "varchar(255)")]
        public string AddTime { get; set; }
    }
}
