using System;
using EasyUi.Components.Dtos;
using Volo.Abp.Application.Services;

namespace EasyUi.Components;

public interface ITagsAppService :
    ICrudAppService< 
        TagsDto, 
        Guid, 
        TagsGetListInput,
        CreateUpdateTagsDto,
        CreateUpdateTagsDto>
{

}