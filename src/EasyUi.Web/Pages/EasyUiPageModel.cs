using EasyUi.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyUi.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class EasyUiPageModel : AbpPageModel
{
    protected EasyUiPageModel()
    {
        LocalizationResourceType = typeof(EasyUiResource);
    }
}
