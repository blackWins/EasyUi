using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyUi.Web.Pages.Components.Tags.ViewModels;

public class CreateTagsViewModel
{
    [Display(Name = "TagsName")]
    public string Name { get; set; }

    [Display(Name = "TagsCode")]
    [TextArea(Rows =6)]
    [Placeholder("<My-Components></My-Components>")]
    public string Code { get; set; }

    [Display(Name = "TagsIsEnable")]
    [DynamicFormIgnore]
    public bool IsEnable { get; set; }

    [Display(Name = "TagAttribute")]
    [TextArea(Rows =6)]
    [InputInfoText("parameters order [name \t type \t defaultValue \t description \n].each param use tab separated.")]
    [Placeholder("propertyName\tpropertyType\tdefaultValue\tpropertyDescription\npropertyName2\tpropertyType2\tdefaultValue2\tpropertyDescription2")]
    //[Placeholder("for example:\ntitle\tText\tthis is title\tThe ElementInfo property specifies additional information about the element\n")]
    public string Properties { get; set; }

    //[Display(Name = "TagsAttribute")]
    //public List<TagAttributeDto> Attribute { get; set; }
}
