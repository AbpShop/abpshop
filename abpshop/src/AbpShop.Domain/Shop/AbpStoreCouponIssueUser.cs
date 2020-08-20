using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_coupon_issue_user")]
    public partial class AbpStoreCouponIssueUser
    {
        [Column("uid", TypeName = "int(10)")]
        public int? Uid { get; set; }
        [Column("issue_coupon_id", TypeName = "int(10)")]
        public int? IssueCouponId { get; set; }
        [Column("add_time", TypeName = "int(10)")]
        public int? AddTime { get; set; }
    }
}
