using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using EasyUi.Components;

namespace EasyUi.Web.Pages.Components.TagAttribute;

public class IndexModel : EasyUiPageModel
{
    public TagAttributeFilterInput TagAttributeFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class TagAttributeFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "TagAttributeName")]
    public string Name { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "TagAttributeType")]
    public EAttributeType? Type { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "TagAttributeDefaultValue")]
    public string DefaultValue { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "TagAttributeDescription")]
    public string Description { get; set; }
}
