using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_shipping_templates")]
    public partial class AbpShippingTemplates
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Required]
        [Column("type")]
        public bool? Type { get; set; }
        [Column("appoint")]
        public bool Appoint { get; set; }
        [Column("sort", TypeName = "int(11)")]
        public int Sort { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int AddTime { get; set; }
    }
}
