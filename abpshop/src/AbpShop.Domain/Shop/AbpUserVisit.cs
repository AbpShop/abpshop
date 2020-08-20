using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_user_visit")]
    public partial class AbpUserVisit
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("uid", TypeName = "int(11)")]
        public int Uid { get; set; }
        [Required]
        [Column("url", TypeName = "varchar(255)")]
        public string Url { get; set; }
        [Required]
        [Column("ip", TypeName = "varchar(255)")]
        public string Ip { get; set; }
        [Column("stay_time", TypeName = "int(11)")]
        public int StayTime { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int AddTime { get; set; }
    }
}
