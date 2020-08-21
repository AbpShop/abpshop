using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace AbpShop
{
    /// <summary>
    /// 生活圈
    /// </summary>
    public class Community : AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 生活圈名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        [Column(TypeName = "decimal(10,6)")]
        public decimal Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        [Column(TypeName = "decimal(10,6)")]
        public decimal Latitude { get; set; }
        /// <summary>
        /// 生活圈Logo
        /// </summary>
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string LogoUrl { get; set; }
    }
}
