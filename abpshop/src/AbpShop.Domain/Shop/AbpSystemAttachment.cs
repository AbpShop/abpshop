using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_attachment")]
    public partial class AbpSystemAttachment
    {
        [Key]
        [Column("att_id", TypeName = "int(10)")]
        public int AttId { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Required]
        [Column("att_dir", TypeName = "varchar(200)")]
        public string AttDir { get; set; }
        [Column("satt_dir", TypeName = "varchar(200)")]
        public string SattDir { get; set; }
        [Required]
        [Column("att_size", TypeName = "char(30)")]
        public string AttSize { get; set; }
        [Required]
        [Column("att_type", TypeName = "char(30)")]
        public string AttType { get; set; }
        [Column("pid", TypeName = "int(10)")]
        public int Pid { get; set; }
        [Column("time", TypeName = "int(11)")]
        public int Time { get; set; }
        [Column("image_type", TypeName = "tinyint(1) unsigned")]
        public byte ImageType { get; set; }
        [Column("module_type", TypeName = "tinyint(1) unsigned")]
        public byte ModuleType { get; set; }
    }
}
