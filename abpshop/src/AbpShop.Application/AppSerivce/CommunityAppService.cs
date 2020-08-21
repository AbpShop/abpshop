using AbpShop.Dto;
using AbpShop.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.Domain.Repositories;

namespace AbpShop.AppSerivce
{
    public class CommunityAppService :
         CrudAppService<Community, CommunityDto, Guid, FilterRequestDto,
                             CreateUpdateCommunityDto, CreateUpdateCommunityDto>,
         ICommunityAppService
    {
        public CommunityAppService(IRepository<Community, Guid> repository)
            : base(repository)
        {

        }
        protected override IQueryable<Community> CreateFilteredQuery(FilterRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .WhereIf(input.Name!=null && input.Name.Trim().Length >0, t => t.Name.Contains(input.Name));
        }

        [AllowAnonymous]
        public override Task<CommunityDto> GetAsync(Guid id)
        {
            return base.GetAsync(id);
        }
        [AllowAnonymous]
        public override Task<PagedResultDto<CommunityDto>> GetListAsync(FilterRequestDto input)
        {
            return base.GetListAsync(input);
        }
        [Authorize(AbpShopPermissions.Community_Create)]
        public async override Task<CommunityDto> CreateAsync(CreateUpdateCommunityDto input)
        {
            var result = await AuthorizationService
        .AuthorizeAsync(AbpShopPermissions.Community_Create);
            if (result.Succeeded == false)
            {
                throw new AbpAuthorizationException("...");
            }
            return await base.CreateAsync(input);
        }
        [Authorize(AbpShopPermissions.Community_Update)]
        public override Task<CommunityDto> UpdateAsync(Guid id, CreateUpdateCommunityDto input)
        {
            return base.UpdateAsync(id, input);
        }
        [Authorize(AbpShopPermissions.Community_Delete)]
        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
    }
}
