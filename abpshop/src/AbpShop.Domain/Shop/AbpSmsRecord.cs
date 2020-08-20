using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_sms_record")]
    public partial class AbpSmsRecord
    {
        [Key]
        [Column("id", TypeName = "int(11) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("uid", TypeName = "varchar(255)")]
        public string Uid { get; set; }
        [Required]
        [Column("phone", TypeName = "char(11)")]
        public string Phone { get; set; }
        [Required]
        [Column("content", TypeName = "text")]
        public string Content { get; set; }
        [Column("add_time", TypeName = "int(11) unsigned")]
        public uint AddTime { get; set; }
        [Required]
        [Column("add_ip", TypeName = "varchar(16)")]
        public string AddIp { get; set; }
        [Required]
        [Column("template", TypeName = "varchar(255)")]
        public string Template { get; set; }
        [Column("resultcode", TypeName = "int(6) unsigned")]
        public uint? Resultcode { get; set; }
        [Column("record_id", TypeName = "int(11) unsigned")]
        public uint RecordId { get; set; }
    }
}
