using Volo.Abp.Settings;

namespace EasyUi.Settings;

public class EasyUiSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(EasyUiSettings.MySetting1));
    }
}
