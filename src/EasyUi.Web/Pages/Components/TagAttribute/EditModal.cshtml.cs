using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyUi.Components;
using EasyUi.Components.Dtos;
using EasyUi.Web.Pages.Components.TagAttribute.ViewModels;

namespace EasyUi.Web.Pages.Components.TagAttribute;

public class EditModalModel : EasyUiPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditTagAttributeViewModel ViewModel { get; set; }

    private readonly ITagAttributeAppService _service;

    public EditModalModel(ITagAttributeAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<TagAttributeDto, CreateEditTagAttributeViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditTagAttributeViewModel, CreateUpdateTagAttributeDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}