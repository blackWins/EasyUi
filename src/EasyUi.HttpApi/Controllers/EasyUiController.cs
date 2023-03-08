using EasyUi.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyUi.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class EasyUiController : AbpControllerBase
{
    protected EasyUiController()
    {
        LocalizationResource = typeof(EasyUiResource);
    }
}
