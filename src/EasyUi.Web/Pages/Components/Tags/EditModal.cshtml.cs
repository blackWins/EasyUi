using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyUi.Components;
using EasyUi.Components.Dtos;
using EasyUi.Web.Pages.Components.Tags.ViewModels;

namespace EasyUi.Web.Pages.Components.Tags;

public class EditModalModel : EasyUiPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditTagsViewModel ViewModel { get; set; }

    private readonly ITagsAppService _service;

    public EditModalModel(ITagsAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<TagsDto, CreateEditTagsViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditTagsViewModel, CreateUpdateTagsDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}