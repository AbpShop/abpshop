using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_user_label_relation")]
    public partial class AbpUserLabelRelation
    {
        [Column("uid", TypeName = "int(11)")]
        public int Uid { get; set; }
        [Column("label_id", TypeName = "int(11)")]
        public int LabelId { get; set; }
    }
}
