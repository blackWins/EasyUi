using System;
using System.Collections.Generic;

namespace EasyUi.Components.Dtos;

[Serializable]
public class CreateUpdateTagsDto
{
    public string Name { get; set; }

    public string Code { get; set; }

    public bool IsEnable { get; set; }

    public ICollection<TagAttributeDto> Attribute { get; set; }
}