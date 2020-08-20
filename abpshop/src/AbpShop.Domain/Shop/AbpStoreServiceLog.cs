using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_service_log")]
    public partial class AbpStoreServiceLog
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("mer_id", TypeName = "int(11)")]
        public int MerId { get; set; }
        [Required]
        [Column("msn", TypeName = "text")]
        public string Msn { get; set; }
        [Column("uid", TypeName = "int(11)")]
        public int Uid { get; set; }
        [Column("to_uid", TypeName = "int(11)")]
        public int ToUid { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int AddTime { get; set; }
        [Column("type")]
        public bool Type { get; set; }
        [Column("remind")]
        public bool Remind { get; set; }
        [Column("msn_type", TypeName = "tinyint(1) unsigned")]
        public byte MsnType { get; set; }
    }
}
