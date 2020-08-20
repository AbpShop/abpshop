using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_user_level")]
    public partial class AbpSystemUserLevel
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("mer_id", TypeName = "int(11)")]
        public int MerId { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column("money", TypeName = "decimal(8,2)")]
        public decimal Money { get; set; }
        [Column("valid_date", TypeName = "int(11)")]
        public int ValidDate { get; set; }
        [Column("is_forever")]
        public bool IsForever { get; set; }
        [Column("is_pay")]
        public bool IsPay { get; set; }
        [Column("is_show")]
        public bool IsShow { get; set; }
        [Column("grade", TypeName = "int(11)")]
        public int Grade { get; set; }
        [Column("discount", TypeName = "decimal(8,2)")]
        public decimal Discount { get; set; }
        [Required]
        [Column("image", TypeName = "varchar(255)")]
        public string Image { get; set; }
        [Required]
        [Column("icon", TypeName = "varchar(255)")]
        public string Icon { get; set; }
        [Required]
        [Column("explain", TypeName = "text")]
        public string Explain { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int AddTime { get; set; }
        [Column("is_del")]
        public bool IsDel { get; set; }
        [Column("exp_num", TypeName = "int(10)")]
        public int ExpNum { get; set; }
    }
}
