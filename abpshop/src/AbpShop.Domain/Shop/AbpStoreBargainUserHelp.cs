using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_bargain_user_help")]
    public partial class AbpStoreBargainUserHelp
    {
        [Key]
        [Column("id", TypeName = "int(11) unsigned")]
        public uint Id { get; set; }
        [Column("uid", TypeName = "int(11) unsigned")]
        public uint? Uid { get; set; }
        [Column("bargain_id", TypeName = "int(11) unsigned")]
        public uint? BargainId { get; set; }
        [Column("bargain_user_id", TypeName = "int(11) unsigned")]
        public uint? BargainUserId { get; set; }
        [Column("price", TypeName = "decimal(8,2) unsigned")]
        public decimal? Price { get; set; }
        [Column("add_time", TypeName = "int(11) unsigned")]
        public uint? AddTime { get; set; }
    }
}
