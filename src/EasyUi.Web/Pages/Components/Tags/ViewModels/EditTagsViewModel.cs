using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyUi.Web.Pages.Components.Tags.ViewModels;

public class EditTagsViewModel
{
    [Display(Name = "TagsName")]
    public string Name { get; set; }

    [Display(Name = "TagsCode")]
    [TextArea(Rows = 6)]
    public string Code { get; set; }

    [Display(Name = "TagsIsEnable")]
    [DynamicFormIgnore]
    public bool IsEnable { get; set; }
}
