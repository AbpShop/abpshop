using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_diy")]
    public partial class AbpDiy
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("version", TypeName = "varchar(255)")]
        public string Version { get; set; }
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column("value", TypeName = "text")]
        public string Value { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int? AddTime { get; set; }
        [Column("update_time", TypeName = "int(11)")]
        public int? UpdateTime { get; set; }
        [Column("status")]
        public bool? Status { get; set; }
        [Column("type")]
        public bool? Type { get; set; }
        [Column("is_del")]
        public bool? IsDel { get; set; }
    }
}
