using System;

namespace EasyUi.Components.Dtos;

[Serializable]
public class CreateUpdateTagAttributeDto
{
    public Guid TagId { get; set; }

    public string Name { get; set; }

    public EAttributeType Type { get; set; }

    public string DefaultValue { get; set; }

    public string Description { get; set; }
}