using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_group_data")]
    public partial class AbpSystemGroupData
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("gid", TypeName = "int(11)")]
        public int Gid { get; set; }
        [Required]
        [Column("value", TypeName = "text")]
        public string Value { get; set; }
        [Column("add_time", TypeName = "int(10)")]
        public int AddTime { get; set; }
        [Column("sort", TypeName = "int(11)")]
        public int Sort { get; set; }
        [Required]
        [Column("status")]
        public bool? Status { get; set; }
    }
}
