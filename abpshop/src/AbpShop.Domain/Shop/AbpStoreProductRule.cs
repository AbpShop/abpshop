using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_product_rule")]
    public partial class AbpStoreProductRule
    {
        [Key]
        [Column("id", TypeName = "int(10)")]
        public int Id { get; set; }
        [Required]
        [Column("rule_name", TypeName = "varchar(32)")]
        public string RuleName { get; set; }
        [Required]
        [Column("rule_value", TypeName = "text")]
        public string RuleValue { get; set; }
    }
}
