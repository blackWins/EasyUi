using EasyUi.Components;
using EasyUi.Components.Dtos;
using AutoMapper;

namespace EasyUi;

public class EasyUiApplicationAutoMapperProfile : Profile
{
    public EasyUiApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Tags, TagsDto>();
        CreateMap<CreateUpdateTagsDto, Tags>(MemberList.Source);
        CreateMap<TagAttribute, TagAttributeDto>();
        CreateMap<CreateUpdateTagAttributeDto, TagAttribute>(MemberList.Source);
        CreateMap<TagAttributeDto, TagAttribute>(MemberList.Source);
    }
}
