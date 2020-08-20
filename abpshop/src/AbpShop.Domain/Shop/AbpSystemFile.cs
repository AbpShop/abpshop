using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_file")]
    public partial class AbpSystemFile
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("cthash", TypeName = "char(32)")]
        public string Cthash { get; set; }
        [Required]
        [Column("filename", TypeName = "varchar(255)")]
        public string Filename { get; set; }
        [Required]
        [Column("atime", TypeName = "char(12)")]
        public string Atime { get; set; }
        [Required]
        [Column("mtime", TypeName = "char(12)")]
        public string Mtime { get; set; }
        [Required]
        [Column("ctime", TypeName = "char(12)")]
        public string Ctime { get; set; }
    }
}
