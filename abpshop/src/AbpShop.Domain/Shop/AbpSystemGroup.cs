using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_group")]
    public partial class AbpSystemGroup
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column("info", TypeName = "varchar(256)")]
        public string Info { get; set; }
        [Required]
        [Column("config_name", TypeName = "varchar(50)")]
        public string ConfigName { get; set; }
        [Column("fields", TypeName = "text")]
        public string Fields { get; set; }
    }
}
