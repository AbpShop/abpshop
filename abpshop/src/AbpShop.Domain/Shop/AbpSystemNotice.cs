using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_notice")]
    public partial class AbpSystemNotice
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(64)")]
        public string Title { get; set; }
        [Required]
        [Column("type", TypeName = "varchar(64)")]
        public string Type { get; set; }
        [Required]
        [Column("icon", TypeName = "varchar(16)")]
        public string Icon { get; set; }
        [Required]
        [Column("url", TypeName = "varchar(64)")]
        public string Url { get; set; }
        [Required]
        [Column("table_title", TypeName = "varchar(256)")]
        public string TableTitle { get; set; }
        [Required]
        [Column("template", TypeName = "varchar(64)")]
        public string Template { get; set; }
        [Required]
        [Column("push_admin", TypeName = "varchar(128)")]
        public string PushAdmin { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte Status { get; set; }
    }
}
