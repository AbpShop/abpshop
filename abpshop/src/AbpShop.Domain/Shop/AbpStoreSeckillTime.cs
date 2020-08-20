using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_seckill_time")]
    public partial class AbpStoreSeckillTime
    {
        [Column("seckill_id", TypeName = "int(10)")]
        public int SeckillId { get; set; }
        [Column("time_id", TypeName = "int(10)")]
        public int TimeId { get; set; }
    }
}
