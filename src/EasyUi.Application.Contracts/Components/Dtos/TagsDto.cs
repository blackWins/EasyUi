using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace EasyUi.Components.Dtos;

[Serializable]
public class TagsDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public string Code { get; set; }

    public bool IsEnable { get; set; }

    public List<TagAttributeDto> Attribute { get; set; }
}