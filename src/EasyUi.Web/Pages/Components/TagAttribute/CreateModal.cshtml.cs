using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyUi.Components;
using EasyUi.Components.Dtos;
using EasyUi.Web.Pages.Components.TagAttribute.ViewModels;

namespace EasyUi.Web.Pages.Components.TagAttribute;

public class CreateModalModel : EasyUiPageModel
{
    [BindProperty]
    public CreateEditTagAttributeViewModel ViewModel { get; set; }

    private readonly ITagAttributeAppService _service;

    public CreateModalModel(ITagAttributeAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditTagAttributeViewModel, CreateUpdateTagAttributeDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}