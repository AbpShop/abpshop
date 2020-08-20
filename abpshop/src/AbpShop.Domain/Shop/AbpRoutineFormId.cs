using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_routine_form_id")]
    public partial class AbpRoutineFormId
    {
        [Key]
        [Column("id", TypeName = "int(11) unsigned")]
        public uint Id { get; set; }
        [Column("uid", TypeName = "int(11)")]
        public int? Uid { get; set; }
        [Required]
        [Column("form_id", TypeName = "varchar(36)")]
        public string FormId { get; set; }
        [Column("stop_time", TypeName = "int(11) unsigned")]
        public uint? StopTime { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte? Status { get; set; }
    }
}
