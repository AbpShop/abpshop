using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_user_extract")]
    public partial class AbpUserExtract
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Column("uid", TypeName = "int(10) unsigned")]
        public uint? Uid { get; set; }
        [Column("real_name", TypeName = "varchar(64)")]
        public string RealName { get; set; }
        [Column("extract_type", TypeName = "varchar(32)")]
        public string ExtractType { get; set; }
        [Column("bank_code", TypeName = "varchar(32)")]
        public string BankCode { get; set; }
        [Column("bank_address", TypeName = "varchar(256)")]
        public string BankAddress { get; set; }
        [Column("alipay_code", TypeName = "varchar(64)")]
        public string AlipayCode { get; set; }
        [Column("extract_price", TypeName = "decimal(8,2) unsigned")]
        public decimal? ExtractPrice { get; set; }
        [Column("mark", TypeName = "varchar(512)")]
        public string Mark { get; set; }
        [Column("balance", TypeName = "decimal(8,2) unsigned")]
        public decimal? Balance { get; set; }
        [Column("fail_msg", TypeName = "varchar(128)")]
        public string FailMsg { get; set; }
        [Column("fail_time", TypeName = "int(10) unsigned")]
        public uint? FailTime { get; set; }
        [Column("add_time", TypeName = "int(10) unsigned")]
        public uint? AddTime { get; set; }
        [Column("status", TypeName = "tinyint(2)")]
        public sbyte? Status { get; set; }
        [Column("wechat", TypeName = "varchar(15)")]
        public string Wechat { get; set; }
        [Required]
        [Column("qrcode_url", TypeName = "varchar(255)")]
        public string QrcodeUrl { get; set; }
    }
}
