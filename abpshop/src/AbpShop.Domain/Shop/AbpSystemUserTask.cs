using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_user_task")]
    public partial class AbpSystemUserTask
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Required]
        [Column("real_name", TypeName = "varchar(255)")]
        public string RealName { get; set; }
        [Required]
        [Column("task_type", TypeName = "varchar(50)")]
        public string TaskType { get; set; }
        [Column("number", TypeName = "int(11)")]
        public int Number { get; set; }
        [Column("level_id", TypeName = "int(11)")]
        public int LevelId { get; set; }
        [Column("sort", TypeName = "int(11)")]
        public int Sort { get; set; }
        [Column("is_show")]
        public bool IsShow { get; set; }
        [Column("is_must")]
        public bool IsMust { get; set; }
        [Required]
        [Column("illustrate", TypeName = "varchar(255)")]
        public string Illustrate { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int AddTime { get; set; }
    }
}
