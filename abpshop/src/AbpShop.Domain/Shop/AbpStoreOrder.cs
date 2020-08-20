using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpShop
{
    [Table("abp_store_order")]
    public partial class AbpStoreOrder
    {
        [Key]
        [Column("id", TypeName = "int(11) unsigned")]
        public uint Id { get; set; }
        [Required]
        [Column("order_id", TypeName = "varchar(32)")]
        public string OrderId { get; set; }
        [Column("uid", TypeName = "int(11) unsigned")]
        public uint Uid { get; set; }
        [Required]
        [Column("real_name", TypeName = "varchar(32)")]
        public string RealName { get; set; }
        [Required]
        [Column("user_phone", TypeName = "varchar(18)")]
        public string UserPhone { get; set; }
        [Required]
        [Column("user_address", TypeName = "varchar(100)")]
        public string UserAddress { get; set; }
        [Required]
        [Column("cart_id", TypeName = "text")]
        public string CartId { get; set; }
        [Column("freight_price", TypeName = "decimal(8,2)")]
        public decimal FreightPrice { get; set; }
        [Column("total_num", TypeName = "int(11) unsigned")]
        public uint TotalNum { get; set; }
        [Column("total_price", TypeName = "decimal(8,2) unsigned")]
        public decimal TotalPrice { get; set; }
        [Column("total_postage", TypeName = "decimal(8,2) unsigned")]
        public decimal TotalPostage { get; set; }
        [Column("pay_price", TypeName = "decimal(8,2) unsigned")]
        public decimal PayPrice { get; set; }
        [Column("pay_postage", TypeName = "decimal(8,2) unsigned")]
        public decimal PayPostage { get; set; }
        [Column("deduction_price", TypeName = "decimal(8,2) unsigned")]
        public decimal DeductionPrice { get; set; }
        [Column("coupon_id", TypeName = "int(11) unsigned")]
        public uint CouponId { get; set; }
        [Column("coupon_price", TypeName = "decimal(8,2) unsigned")]
        public decimal CouponPrice { get; set; }
        [Column("paid", TypeName = "tinyint(1) unsigned")]
        public byte Paid { get; set; }
        [Column("pay_time", TypeName = "int(11) unsigned")]
        public uint? PayTime { get; set; }
        [Required]
        [Column("pay_type", TypeName = "varchar(32)")]
        public string PayType { get; set; }
        [Column("add_time", TypeName = "int(11) unsigned")]
        public uint AddTime { get; set; }
        [Column("status")]
        public bool Status { get; set; }
        [Column("refund_status", TypeName = "tinyint(1) unsigned")]
        public byte RefundStatus { get; set; }
        [Column("refund_reason_wap_img", TypeName = "varchar(2000)")]
        public string RefundReasonWapImg { get; set; }
        [Column("refund_reason_wap_explain", TypeName = "varchar(255)")]
        public string RefundReasonWapExplain { get; set; }
        [Column("refund_reason_time", TypeName = "int(11) unsigned")]
        public uint? RefundReasonTime { get; set; }
        [Column("refund_reason_wap", TypeName = "varchar(255)")]
        public string RefundReasonWap { get; set; }
        [Column("refund_reason", TypeName = "varchar(255)")]
        public string RefundReason { get; set; }
        [Column("refund_price", TypeName = "decimal(8,2) unsigned")]
        public decimal RefundPrice { get; set; }
        [Column("delivery_name", TypeName = "varchar(64)")]
        public string DeliveryName { get; set; }
        [Column("delivery_type", TypeName = "varchar(32)")]
        public string DeliveryType { get; set; }
        [Column("delivery_id", TypeName = "varchar(64)")]
        public string DeliveryId { get; set; }
        [Column("gain_integral", TypeName = "decimal(8,2) unsigned")]
        public decimal GainIntegral { get; set; }
        [Column("use_integral", TypeName = "decimal(8,2) unsigned")]
        public decimal UseIntegral { get; set; }
        [Column("back_integral", TypeName = "decimal(8,2) unsigned")]
        public decimal? BackIntegral { get; set; }
        [Required]
        [Column("mark", TypeName = "varchar(512)")]
        public string Mark { get; set; }
        [Column("is_del", TypeName = "tinyint(1) unsigned")]
        public byte IsDel { get; set; }
        [Required]
        [Column("unique", TypeName = "char(32)")]
        public string Unique { get; set; }
        [Column("remark", TypeName = "varchar(512)")]
        public string Remark { get; set; }
        [Column("mer_id", TypeName = "int(10) unsigned")]
        public uint MerId { get; set; }
        [Column("is_mer_check", TypeName = "tinyint(3) unsigned")]
        public byte IsMerCheck { get; set; }
        [Column("combination_id", TypeName = "int(11) unsigned")]
        public uint? CombinationId { get; set; }
        [Column("pink_id", TypeName = "int(11) unsigned")]
        public uint PinkId { get; set; }
        [Column("cost", TypeName = "decimal(8,2) unsigned")]
        public decimal Cost { get; set; }
        [Column("seckill_id", TypeName = "int(11) unsigned")]
        public uint SeckillId { get; set; }
        [Column("bargain_id", TypeName = "int(11) unsigned")]
        public uint? BargainId { get; set; }
        [Required]
        [Column("verify_code", TypeName = "varchar(12)")]
        public string VerifyCode { get; set; }
        [Column("store_id", TypeName = "int(11)")]
        public int StoreId { get; set; }
        [Required]
        [Column("shipping_type")]
        public bool? ShippingType { get; set; }
        [Column("clerk_id", TypeName = "int(11)")]
        public int ClerkId { get; set; }
        [Column("is_channel", TypeName = "tinyint(1) unsigned")]
        public byte? IsChannel { get; set; }
        [Column("is_remind", TypeName = "tinyint(1) unsigned")]
        public byte? IsRemind { get; set; }
        [Column("is_system_del")]
        public bool? IsSystemDel { get; set; }
    }
}
