using AbpShop.Dto;
using AutoMapper;

namespace AbpShop
{
    public class AbpShopApplicationAutoMapperProfile : Profile
    {
        public AbpShopApplicationAutoMapperProfile()
        {
            CreateMap<Community, CommunityDto>();
            CreateMap<CreateUpdateCommunityDto, Community>();
        }
    }
}
