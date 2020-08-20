using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_category")]
    public partial class AbpStoreCategory
    {
        [Key]
        [Column("id", TypeName = "mediumint(11)")]
        public int Id { get; set; }
        [Column("pid", TypeName = "mediumint(11)")]
        public int Pid { get; set; }
        [Required]
        [Column("cate_name", TypeName = "varchar(100)")]
        public string CateName { get; set; }
        [Column("sort", TypeName = "mediumint(11)")]
        public int Sort { get; set; }
        [Required]
        [Column("pic", TypeName = "varchar(128)")]
        public string Pic { get; set; }
        [Required]
        [Column("is_show")]
        public bool? IsShow { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int AddTime { get; set; }
    }
}
