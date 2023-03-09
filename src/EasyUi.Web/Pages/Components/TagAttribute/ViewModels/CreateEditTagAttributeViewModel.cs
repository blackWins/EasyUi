using System;
using System.ComponentModel.DataAnnotations;
using EasyUi.Components;

namespace EasyUi.Web.Pages.Components.TagAttribute.ViewModels;

public class CreateEditTagAttributeViewModel
{
    [Display(Name = "TagAttributeTagId")]
    public Guid TagId { get; set; }

    [Display(Name = "TagAttributeName")]
    public string Name { get; set; }

    [Display(Name = "TagAttributeType")]
    public EAttributeType Type { get; set; }

    [Display(Name = "TagAttributeDefaultValue")]
    public string DefaultValue { get; set; }

    [Display(Name = "TagAttributeDescription")]
    public string Description { get; set; }
}
