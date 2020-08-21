using AbpShop.Dto;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpShop
{
    public interface ICommunityAppService :
        ICrudAppService< //定义了CRUD方法
            CommunityDto, //用来展示
            Guid, //实体的主键
            FilterRequestDto, //获取的时候用于分页和排序
            CreateUpdateCommunityDto, //用于创建
            CreateUpdateCommunityDto> //用于更新
    {
    }
}
