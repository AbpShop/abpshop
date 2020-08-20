using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_notice_admin")]
    public partial class AbpSystemNoticeAdmin
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("notice_type", TypeName = "varchar(64)")]
        public string NoticeType { get; set; }
        [Column("admin_id", TypeName = "smallint(5) unsigned")]
        public ushort AdminId { get; set; }
        [Column("link_id", TypeName = "int(10) unsigned")]
        public uint LinkId { get; set; }
        [Required]
        [Column("table_data", TypeName = "text")]
        public string TableData { get; set; }
        [Column("is_click", TypeName = "tinyint(3) unsigned")]
        public byte IsClick { get; set; }
        [Column("is_visit", TypeName = "tinyint(3) unsigned")]
        public byte IsVisit { get; set; }
        [Column("visit_time", TypeName = "int(11)")]
        public int VisitTime { get; set; }
        [Column("add_time", TypeName = "int(10) unsigned")]
        public uint AddTime { get; set; }
    }
}
