using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace EasyUi.Components.Dtos;

[Serializable]
public class TagAttributeGetListInput : PagedAndSortedResultRequestDto
{
    public Guid? TagId { get; set; }

    public string Name { get; set; }

    public EAttributeType? Type { get; set; }

    public string DefaultValue { get; set; }

    public string Description { get; set; }
}