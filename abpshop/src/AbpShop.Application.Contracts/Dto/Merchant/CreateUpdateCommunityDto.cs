using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbpShop.Dto
{
    public class CreateUpdateCommunityDto
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public decimal Longitude { get; set; }
        [Required]
        public decimal Latitude { get; set; }
        [Required]
        public string LogoUrl { get; set; }
    }
}
