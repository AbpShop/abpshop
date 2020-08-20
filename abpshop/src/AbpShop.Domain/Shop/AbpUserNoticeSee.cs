using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_user_notice_see")]
    public partial class AbpUserNoticeSee
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("nid", TypeName = "int(11)")]
        public int Nid { get; set; }
        [Column("uid", TypeName = "int(11)")]
        public int Uid { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int AddTime { get; set; }
    }
}
