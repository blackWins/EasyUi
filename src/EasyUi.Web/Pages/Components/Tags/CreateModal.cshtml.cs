using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyUi.Components;
using EasyUi.Components.Dtos;
using EasyUi.Web.Pages.Components.Tags.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace EasyUi.Web.Pages.Components.Tags;

public class CreateModalModel : EasyUiPageModel
{
    [BindProperty]
    public CreateEditTagsViewModel ViewModel { get; set; }

    private readonly ITagsAppService _service;

    public CreateModalModel(ITagsAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditTagsViewModel, CreateUpdateTagsDto>(ViewModel);
        var attributes = new List<TagAttributeDto>();
        var arr = ViewModel.Properties.Split(new[] { '\t', '\n' }).ToList();
        for (int i = 0; i < arr.Count; i+=4)
        {
            attributes.Add(new TagAttributeDto()
            {
                Name = arr[i].ToString(),
                Type = (EAttributeType)System.Enum.Parse(typeof(EAttributeType), arr[i + 1]),
                DefaultValue = arr[i + 2].ToString(),
                Description = arr[i + 3].ToString()
            });
        }
        dto.Attribute = attributes;
        await _service.CreateAsync(dto);
        return NoContent();
    }

}