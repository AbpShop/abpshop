using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_user_sign")]
    public partial class AbpUserSign
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("uid", TypeName = "int(11)")]
        public int Uid { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(255)")]
        public string Title { get; set; }
        [Column("number", TypeName = "int(11)")]
        public int Number { get; set; }
        [Column("balance", TypeName = "int(11)")]
        public int Balance { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int AddTime { get; set; }
    }
}
