using System;
using EasyUi.Components.Dtos;
using Volo.Abp.Application.Services;

namespace EasyUi.Components;

public interface ITagAttributeAppService :
    ICrudAppService< 
        TagAttributeDto, 
        Guid, 
        TagAttributeGetListInput,
        CreateUpdateTagAttributeDto,
        CreateUpdateTagAttributeDto>
{

}