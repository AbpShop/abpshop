using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_config_tab")]
    public partial class AbpSystemConfigTab
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Column("pid", TypeName = "int(11)")]
        public int Pid { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(255)")]
        public string Title { get; set; }
        [Required]
        [Column("eng_title", TypeName = "varchar(255)")]
        public string EngTitle { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte Status { get; set; }
        [Column("info", TypeName = "tinyint(1) unsigned")]
        public byte Info { get; set; }
        [Column("icon", TypeName = "varchar(30)")]
        public string Icon { get; set; }
        [Column("type", TypeName = "int(2)")]
        public int? Type { get; set; }
        [Column("sort", TypeName = "int(11)")]
        public int Sort { get; set; }
    }
}
