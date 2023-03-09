using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace EasyUi.Components.Dtos;

[Serializable]
public class TagsGetListInput : PagedAndSortedResultRequestDto
{
    public string Name { get; set; }

    public string Code { get; set; }

    public bool? IsEnable { get; set; }
}