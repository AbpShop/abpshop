using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_template_message")]
    public partial class AbpTemplateMessage
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Column("type")]
        public bool Type { get; set; }
        [Required]
        [Column("tempkey", TypeName = "char(50)")]
        public string Tempkey { get; set; }
        [Required]
        [Column("name", TypeName = "char(100)")]
        public string Name { get; set; }
        [Required]
        [Column("content", TypeName = "varchar(1000)")]
        public string Content { get; set; }
        [Column("tempid", TypeName = "char(100)")]
        public string Tempid { get; set; }
        [Required]
        [Column("add_time", TypeName = "varchar(15)")]
        public string AddTime { get; set; }
        [Column("status", TypeName = "tinyint(4)")]
        public sbyte Status { get; set; }
    }
}
