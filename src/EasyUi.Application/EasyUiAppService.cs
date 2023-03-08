using System;
using System.Collections.Generic;
using System.Text;
using EasyUi.Localization;
using Volo.Abp.Application.Services;

namespace EasyUi;

/* Inherit your application services from this class.
 */
public abstract class EasyUiAppService : ApplicationService
{
    protected EasyUiAppService()
    {
        LocalizationResource = typeof(EasyUiResource);
    }
}
