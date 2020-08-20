using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_cache")]
    public partial class AbpCache
    {
        [Key]
        [Column("key", TypeName = "varchar(32)")]
        public string Key { get; set; }
        [Column("result", TypeName = "text")]
        public string Result { get; set; }
        [Column("expire_time", TypeName = "int(11)")]
        public int ExpireTime { get; set; }
        [Column("add_time", TypeName = "int(10)")]
        public int? AddTime { get; set; }
    }
}
