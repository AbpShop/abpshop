using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_user_task_finish")]
    public partial class AbpUserTaskFinish
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("task_id", TypeName = "int(11)")]
        public int TaskId { get; set; }
        [Column("uid", TypeName = "int(11)")]
        public int Uid { get; set; }
        [Column("status")]
        public bool Status { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int AddTime { get; set; }
    }
}
