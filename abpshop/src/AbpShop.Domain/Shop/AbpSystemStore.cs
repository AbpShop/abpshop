using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_store")]
    public partial class AbpSystemStore
    {
        [Key]
        [Column("id", TypeName = "int(10) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Required]
        [Column("introduction", TypeName = "varchar(1000)")]
        public string Introduction { get; set; }
        [Required]
        [Column("phone", TypeName = "char(25)")]
        public string Phone { get; set; }
        [Required]
        [Column("address", TypeName = "varchar(255)")]
        public string Address { get; set; }
        [Required]
        [Column("detailed_address", TypeName = "varchar(255)")]
        public string DetailedAddress { get; set; }
        [Required]
        [Column("image", TypeName = "varchar(255)")]
        public string Image { get; set; }
        [Required]
        [Column("latitude", TypeName = "char(25)")]
        public string Latitude { get; set; }
        [Required]
        [Column("longitude", TypeName = "char(25)")]
        public string Longitude { get; set; }
        [Required]
        [Column("valid_time", TypeName = "varchar(100)")]
        public string ValidTime { get; set; }
        [Required]
        [Column("day_time", TypeName = "varchar(100)")]
        public string DayTime { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int AddTime { get; set; }
        [Column("is_show")]
        public bool IsShow { get; set; }
        [Column("is_del")]
        public bool IsDel { get; set; }
    }
}
