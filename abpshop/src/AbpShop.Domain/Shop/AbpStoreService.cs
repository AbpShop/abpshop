using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_service")]
    public partial class AbpStoreService
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("mer_id", TypeName = "int(11)")]
        public int MerId { get; set; }
        [Column("uid", TypeName = "int(11)")]
        public int Uid { get; set; }
        [Required]
        [Column("avatar", TypeName = "varchar(250)")]
        public string Avatar { get; set; }
        [Required]
        [Column("nickname", TypeName = "varchar(50)")]
        public string Nickname { get; set; }
        [Required]
        [Column("phone", TypeName = "varchar(20)")]
        public string Phone { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int AddTime { get; set; }
        [Column("status", TypeName = "tinyint(1) unsigned")]
        public byte Status { get; set; }
        [Column("notify", TypeName = "int(2)")]
        public int? Notify { get; set; }
        [Column("customer")]
        public bool Customer { get; set; }
    }
}
