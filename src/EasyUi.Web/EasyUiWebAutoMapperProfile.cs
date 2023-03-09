using AutoMapper;
using EasyUi.Components.Dtos;
using EasyUi.Web.Pages.Components.TagAttribute.ViewModels;
using EasyUi.Web.Pages.Components.Tags.ViewModels;

namespace EasyUi.Web;

public class EasyUiWebAutoMapperProfile : Profile
{
    public EasyUiWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<TagsDto, CreateEditTagsViewModel>();
        CreateMap<CreateEditTagsViewModel, CreateUpdateTagsDto>();
        CreateMap<TagAttributeDto, CreateEditTagAttributeViewModel>();
        CreateMap<CreateEditTagAttributeViewModel, CreateUpdateTagAttributeDto>();
    }
}
