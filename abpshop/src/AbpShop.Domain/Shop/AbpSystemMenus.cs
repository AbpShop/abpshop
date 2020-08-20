using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_menus")]
    public partial class AbpSystemMenus
    {
        [Key]
        [Column("id", TypeName = "smallint(5) unsigned")]
        public ushort Id { get; set; }
        [Column("pid", TypeName = "smallint(5) unsigned")]
        public ushort Pid { get; set; }
        [Required]
        [Column("icon", TypeName = "varchar(16)")]
        public string Icon { get; set; }
        [Required]
        [Column("menu_name", TypeName = "varchar(32)")]
        public string MenuName { get; set; }
        [Required]
        [Column("module", TypeName = "varchar(32)")]
        public string Module { get; set; }
        [Required]
        [Column("controller", TypeName = "varchar(64)")]
        public string Controller { get; set; }
        [Required]
        [Column("action", TypeName = "varchar(32)")]
        public string Action { get; set; }
        [Required]
        [Column("api_url", TypeName = "varchar(100)")]
        public string ApiUrl { get; set; }
        [Required]
        [Column("methods", TypeName = "varchar(10)")]
        public string Methods { get; set; }
        [Required]
        [Column("params", TypeName = "varchar(128)")]
        public string Params { get; set; }
        [Column("sort", TypeName = "tinyint(3)")]
        public sbyte Sort { get; set; }
        [Column("is_show", TypeName = "tinyint(1) unsigned")]
        public byte IsShow { get; set; }
        [Column("is_show_path")]
        public bool IsShowPath { get; set; }
        [Column("access", TypeName = "tinyint(1) unsigned")]
        public byte Access { get; set; }
        [Required]
        [Column("menu_path", TypeName = "varchar(128)")]
        public string MenuPath { get; set; }
        [Column("auth_type")]
        public bool AuthType { get; set; }
        [Required]
        [Column("header", TypeName = "varchar(50)")]
        public string Header { get; set; }
        [Column("is_header")]
        public bool IsHeader { get; set; }
        [Required]
        [Column("unique_auth", TypeName = "varchar(150)")]
        public string UniqueAuth { get; set; }
        [Column("is_del")]
        public bool IsDel { get; set; }
    }
}
