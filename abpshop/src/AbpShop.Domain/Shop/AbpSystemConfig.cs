using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_config")]
    public partial class AbpSystemConfig
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("menu_name", TypeName = "varchar(255)")]
        public string MenuName { get; set; }
        [Required]
        [Column("type", TypeName = "varchar(255)")]
        public string Type { get; set; }
        [Column("input_type", TypeName = "varchar(20)")]
        public string InputType { get; set; }
        [Column("config_tab_id", TypeName = "int(10) unsigned")]
        public uint ConfigTabId { get; set; }
        [Column("parameter", TypeName = "varchar(255)")]
        public string Parameter { get; set; }
        [Column("upload_type", TypeName = "tinyint(1) unsigned")]
        public byte? UploadType { get; set; }
        [Column("required", TypeName = "varchar(255)")]
        public string Required { get; set; }
        [Column("width", TypeName = "int(10) unsigned")]
        public uint? Width { get; set; }
        [Column("high", TypeName = "int(10) unsigned")]
        public uint? High { get; set; }
        [Column("value", TypeName = "varchar(5000)")]
        public string Value { get; set; }
        [Required]
        [Column("info", TypeName = "varchar(255)")]
        public string Info { get; set; }
        [Column("desc", TypeName = "varchar(255)")]
        public string Desc { get; set; }
        [Column("sort", TypeName = "int(10) unsigned")]
        public uint Sort { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte Status { get; set; }
    }
}
