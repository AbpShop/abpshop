using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_user_level")]
    public partial class AbpUserLevel
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("uid", TypeName = "int(11)")]
        public int Uid { get; set; }
        [Column("level_id", TypeName = "int(11)")]
        public int LevelId { get; set; }
        [Column("grade", TypeName = "int(11)")]
        public int Grade { get; set; }
        [Column("valid_time", TypeName = "int(11)")]
        public int ValidTime { get; set; }
        [Column("is_forever")]
        public bool IsForever { get; set; }
        [Column("mer_id", TypeName = "int(11)")]
        public int MerId { get; set; }
        [Column("status")]
        public bool Status { get; set; }
        [Required]
        [Column("mark", TypeName = "varchar(255)")]
        public string Mark { get; set; }
        [Column("remind")]
        public bool Remind { get; set; }
        [Column("is_del")]
        public bool IsDel { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int AddTime { get; set; }
        [Column("discount", TypeName = "int(11)")]
        public int Discount { get; set; }
    }
}
