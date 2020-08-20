using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_routine_access_token")]
    public partial class AbpRoutineAccessToken
    {
        [Key]
        [Column("id", TypeName = "int(11) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("access_token", TypeName = "varchar(256)")]
        public string AccessToken { get; set; }
        [Column("stop_time", TypeName = "int(11) unsigned")]
        public uint StopTime { get; set; }
    }
}
