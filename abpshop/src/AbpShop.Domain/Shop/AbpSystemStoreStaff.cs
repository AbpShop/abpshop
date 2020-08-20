using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_store_staff")]
    public partial class AbpSystemStoreStaff
    {
        [Key]
        [Column("id", TypeName = "int(11) unsigned")]
        public uint Id { get; set; }
        [Column("uid", TypeName = "int(10) unsigned")]
        public uint Uid { get; set; }
        [Required]
        [Column("avatar", TypeName = "varchar(255)")]
        public string Avatar { get; set; }
        [Column("store_id", TypeName = "int(11)")]
        public int StoreId { get; set; }
        [Column("staff_name", TypeName = "varchar(64)")]
        public string StaffName { get; set; }
        [Column("phone", TypeName = "char(15)")]
        public string Phone { get; set; }
        [Column("verify_status", TypeName = "tinyint(2)")]
        public sbyte VerifyStatus { get; set; }
        [Column("status", TypeName = "tinyint(2)")]
        public sbyte? Status { get; set; }
        [Column("add_time", TypeName = "int(10)")]
        public int? AddTime { get; set; }
    }
}
