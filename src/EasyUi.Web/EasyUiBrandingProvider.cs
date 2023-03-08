using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace EasyUi.Web;

[Dependency(ReplaceServices = true)]
public class EasyUiBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EasyUi";
}
