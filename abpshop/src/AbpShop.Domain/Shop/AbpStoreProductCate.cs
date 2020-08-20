using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_product_cate")]
    public partial class AbpStoreProductCate
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("product_id", TypeName = "int(11)")]
        public int ProductId { get; set; }
        [Column("cate_id", TypeName = "int(11)")]
        public int CateId { get; set; }
        [Column("add_time", TypeName = "int(11)")]
        public int AddTime { get; set; }
    }
}
