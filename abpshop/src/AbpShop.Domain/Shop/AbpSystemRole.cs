using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_role")]
    public partial class AbpSystemRole
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("role_name", TypeName = "varchar(32)")]
        public string RoleName { get; set; }
        [Required]
        [Column("rules", TypeName = "text")]
        public string Rules { get; set; }
        [Column("level", TypeName = "tinyint(3) unsigned")]
        public byte Level { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte Status { get; set; }
    }
}
