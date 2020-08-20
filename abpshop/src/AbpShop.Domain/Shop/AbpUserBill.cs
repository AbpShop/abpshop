using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_user_bill")]
    public partial class AbpUserBill
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Column("uid", TypeName = "int(10) unsigned")]
        public uint Uid { get; set; }
        [Required]
        [Column("link_id", TypeName = "varchar(32)")]
        public string LinkId { get; set; }
        [Column("pm", TypeName = "tinyint(1) unsigned")]
        public byte Pm { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(64)")]
        public string Title { get; set; }
        [Required]
        [Column("category", TypeName = "varchar(64)")]
        public string Category { get; set; }
        [Required]
        [Column("type", TypeName = "varchar(64)")]
        public string Type { get; set; }
        [Column("number", TypeName = "decimal(8,2) unsigned")]
        public decimal Number { get; set; }
        [Column("balance", TypeName = "decimal(8,2) unsigned")]
        public decimal Balance { get; set; }
        [Required]
        [Column("mark", TypeName = "varchar(512)")]
        public string Mark { get; set; }
        [Column("add_time", TypeName = "int(10) unsigned")]
        public uint AddTime { get; set; }
        [Required]
        [Column("status")]
        public bool? Status { get; set; }
        [Column("take")]
        public bool Take { get; set; }
    }
}
