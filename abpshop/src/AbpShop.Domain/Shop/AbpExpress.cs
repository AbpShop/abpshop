using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_express")]
    public partial class AbpExpress
    {
        [Key]
        [Column("id", TypeName = "mediumint(11) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("code", TypeName = "varchar(50)")]
        public string Code { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column("sort", TypeName = "int(11)")]
        public int Sort { get; set; }
        [Column("is_show")]
        public bool IsShow { get; set; }
    }
}
