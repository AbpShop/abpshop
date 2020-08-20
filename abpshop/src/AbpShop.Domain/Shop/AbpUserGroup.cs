using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_user_group")]
    public partial class AbpUserGroup
    {
        [Key]
        [Column("id", TypeName = "smallint(5) unsigned")]
        public ushort Id { get; set; }
        [Column("group_name", TypeName = "varchar(64)")]
        public string GroupName { get; set; }
    }
}
