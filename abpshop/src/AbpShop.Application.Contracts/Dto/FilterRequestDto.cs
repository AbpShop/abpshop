using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpShop.Dto
{
    public class FilterRequestDto : PagedAndSortedResultRequestDto
    {
        public String Name { get; set; }
    }
}
