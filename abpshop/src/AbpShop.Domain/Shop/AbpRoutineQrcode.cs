using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_routine_qrcode")]
    public partial class AbpRoutineQrcode
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("third_type", TypeName = "varchar(32)")]
        public string ThirdType { get; set; }
        [Column("third_id", TypeName = "int(11) unsigned")]
        public uint ThirdId { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte? Status { get; set; }
        [Column("add_time", TypeName = "varchar(255)")]
        public string AddTime { get; set; }
        [Column("page", TypeName = "varchar(255)")]
        public string Page { get; set; }
        [Column("qrcode_url", TypeName = "varchar(255)")]
        public string QrcodeUrl { get; set; }
        [Column("url_time", TypeName = "int(11) unsigned")]
        public uint? UrlTime { get; set; }
    }
}
