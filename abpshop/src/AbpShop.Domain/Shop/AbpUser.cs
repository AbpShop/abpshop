using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_user")]
    public partial class AbpUser
    {
        [Key]
        [Column("uid", TypeName = "int(10) unsigned")]
        public uint Uid { get; set; }
        [Required]
        [Column("account", TypeName = "varchar(32)")]
        public string Account { get; set; }
        [Required]
        [Column("pwd", TypeName = "varchar(32)")]
        public string Pwd { get; set; }
        [Required]
        [Column("real_name", TypeName = "varchar(25)")]
        public string RealName { get; set; }
        [Column("birthday", TypeName = "int(11)")]
        public int Birthday { get; set; }
        [Required]
        [Column("card_id", TypeName = "varchar(20)")]
        public string CardId { get; set; }
        [Required]
        [Column("mark", TypeName = "varchar(255)")]
        public string Mark { get; set; }
        [Column("partner_id", TypeName = "int(11)")]
        public int PartnerId { get; set; }
        [Column("group_id", TypeName = "int(11)")]
        public int GroupId { get; set; }
        [Required]
        [Column("nickname", TypeName = "varchar(60)")]
        public string Nickname { get; set; }
        [Required]
        [Column("avatar", TypeName = "varchar(256)")]
        public string Avatar { get; set; }
        [Column("phone", TypeName = "char(15)")]
        public string Phone { get; set; }
        [Column("add_time", TypeName = "int(11) unsigned")]
        public uint AddTime { get; set; }
        [Required]
        [Column("add_ip", TypeName = "varchar(16)")]
        public string AddIp { get; set; }
        [Column("last_time", TypeName = "int(11) unsigned")]
        public uint LastTime { get; set; }
        [Required]
        [Column("last_ip", TypeName = "varchar(16)")]
        public string LastIp { get; set; }
        [Column("now_money", TypeName = "decimal(8,2) unsigned")]
        public decimal NowMoney { get; set; }
        [Column("brokerage_price", TypeName = "decimal(8,2)")]
        public decimal BrokeragePrice { get; set; }
        [Column("integral", TypeName = "decimal(8,2) unsigned")]
        public decimal Integral { get; set; }
        [Column("exp", TypeName = "decimal(8,2) unsigned")]
        public decimal Exp { get; set; }
        [Column("sign_num", TypeName = "int(11)")]
        public int SignNum { get; set; }
        [Required]
        [Column("status")]
        public bool? Status { get; set; }
        [Column("level", TypeName = "tinyint(2) unsigned")]
        public byte Level { get; set; }
        [Column("spread_uid", TypeName = "int(10) unsigned")]
        public uint SpreadUid { get; set; }
        [Column("spread_time", TypeName = "int(11) unsigned")]
        public uint SpreadTime { get; set; }
        [Required]
        [Column("user_type", TypeName = "varchar(32)")]
        public string UserType { get; set; }
        [Column("is_promoter", TypeName = "tinyint(1) unsigned")]
        public byte IsPromoter { get; set; }
        [Column("pay_count", TypeName = "int(11) unsigned")]
        public uint? PayCount { get; set; }
        [Column("spread_count", TypeName = "int(11)")]
        public int? SpreadCount { get; set; }
        [Column("clean_time", TypeName = "int(11)")]
        public int? CleanTime { get; set; }
        [Required]
        [Column("addres", TypeName = "varchar(255)")]
        public string Addres { get; set; }
        [Column("adminid", TypeName = "int(11) unsigned")]
        public uint? Adminid { get; set; }
        [Required]
        [Column("login_type", TypeName = "varchar(36)")]
        public string LoginType { get; set; }
    }
}
