using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_system_attachment_category")]
    public partial class AbpSystemAttachmentCategory
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("pid", TypeName = "int(11)")]
        public int? Pid { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column("enname", TypeName = "varchar(50)")]
        public string Enname { get; set; }
    }
}
