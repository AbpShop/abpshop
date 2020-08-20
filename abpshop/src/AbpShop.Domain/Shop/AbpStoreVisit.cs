using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_visit")]
    public partial class AbpStoreVisit
    {
        [Key]
        [Column("id", TypeName = "int(10)")]
        public int Id { get; set; }
        [Column("product_id", TypeName = "int(11)")]
        public int? ProductId { get; set; }
        [Column("product_type", TypeName = "varchar(32)")]
        public string ProductType { get; set; }
        [Column("cate_id", TypeName = "int(11)")]
        public int? CateId { get; set; }
        [Column("type", TypeName = "char(50)")]
        public string Type { get; set; }
        [Column("uid", TypeName = "int(11)")]
        public int? Uid { get; set; }
        [Column("count", TypeName = "int(11)")]
        public int? Count { get; set; }
        [Column("content", TypeName = "varchar(255)")]
        public string Content { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int? AddTime { get; set; }
    }
}
