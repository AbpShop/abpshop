using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_city")]
    public partial class AbpSystemCity
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("city_id", TypeName = "int(11)")]
        public int CityId { get; set; }
        [Column("level", TypeName = "int(11)")]
        public int Level { get; set; }
        [Column("parent_id", TypeName = "int(11)")]
        public int ParentId { get; set; }
        [Required]
        [Column("area_code", TypeName = "varchar(30)")]
        public string AreaCode { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Required]
        [Column("merger_name", TypeName = "varchar(255)")]
        public string MergerName { get; set; }
        [Required]
        [Column("lng", TypeName = "varchar(50)")]
        public string Lng { get; set; }
        [Required]
        [Column("lat", TypeName = "varchar(50)")]
        public string Lat { get; set; }
        [Required]
        [Column("is_show")]
        public bool? IsShow { get; set; }
    }
}
