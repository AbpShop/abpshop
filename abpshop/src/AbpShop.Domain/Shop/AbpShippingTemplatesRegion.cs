using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_shipping_templates_region")]
    public partial class AbpShippingTemplatesRegion
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("province_id", TypeName = "int(11)")]
        public int ProvinceId { get; set; }
        [Column("temp_id", TypeName = "int(11)")]
        public int TempId { get; set; }
        [Column("city_id", TypeName = "int(11)")]
        public int CityId { get; set; }
        [Column("first", TypeName = "decimal(10,2)")]
        public decimal First { get; set; }
        [Column("first_price", TypeName = "decimal(10,2)")]
        public decimal FirstPrice { get; set; }
        [Column("continue", TypeName = "decimal(10,2)")]
        public decimal Continue { get; set; }
        [Column("continue_price", TypeName = "decimal(10,2)")]
        public decimal ContinuePrice { get; set; }
        [Required]
        [Column("type")]
        public bool? Type { get; set; }
        [Required]
        [Column("uniqid", TypeName = "varchar(32)")]
        public string Uniqid { get; set; }
    }
}
