using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_user_address")]
    public partial class AbpUserAddress
    {
        [Key]
        [Column("id", TypeName = "mediumint(8) unsigned")]
        public uint Id { get; set; }
        [Column("uid", TypeName = "int(10) unsigned")]
        public uint Uid { get; set; }
        [Required]
        [Column("real_name", TypeName = "varchar(32)")]
        public string RealName { get; set; }
        [Required]
        [Column("phone", TypeName = "varchar(16)")]
        public string Phone { get; set; }
        [Required]
        [Column("province", TypeName = "varchar(64)")]
        public string Province { get; set; }
        [Required]
        [Column("city", TypeName = "varchar(64)")]
        public string City { get; set; }
        [Column("city_id", TypeName = "int(11)")]
        public int CityId { get; set; }
        [Required]
        [Column("district", TypeName = "varchar(64)")]
        public string District { get; set; }
        [Required]
        [Column("detail", TypeName = "varchar(256)")]
        public string Detail { get; set; }
        [Column("post_code", TypeName = "int(10) unsigned")]
        public uint PostCode { get; set; }
        [Required]
        [Column("longitude", TypeName = "varchar(16)")]
        public string Longitude { get; set; }
        [Required]
        [Column("latitude", TypeName = "varchar(16)")]
        public string Latitude { get; set; }
        [Column("is_default", TypeName = "tinyint(1) unsigned")]
        public byte IsDefault { get; set; }
        [Column("is_del", TypeName = "tinyint(1) unsigned")]
        public byte IsDel { get; set; }
        [Column("add_time", TypeName = "int(10) unsigned")]
        public uint AddTime { get; set; }
    }
}
