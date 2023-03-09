using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyUi.Web.Pages.Components.Tags;

public class IndexModel : EasyUiPageModel
{
    public TagsFilterInput TagsFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class TagsFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "TagsName")]
    public string Name { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "TagsCode")]
    public string Code { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "TagsIsEnable")]
    public bool? IsEnable { get; set; }
}
