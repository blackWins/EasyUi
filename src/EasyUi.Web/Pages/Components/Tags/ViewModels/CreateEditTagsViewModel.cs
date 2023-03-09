using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyUi.Web.Pages.Components.Tags.ViewModels;

public class CreateEditTagsViewModel
{
    [Display(Name = "TagsName")]
    public string Name { get; set; }

    [Display(Name = "TagsCode")]
    [TextArea(Rows =4)]
    public string Code { get; set; }

    [Display(Name = "TagsIsEnable")]
    [DynamicFormIgnore]
    public bool IsEnable { get; set; }

    [TextArea(Rows =6)]
    public string Properties { get; set; }

    //[Display(Name = "TagsAttribute")]
    //public List<TagAttributeDto> Attribute { get; set; }
}
