using EasyUi.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyUi.Permissions;

public class EasyUiPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(EasyUiPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(EasyUiPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EasyUiResource>(name);
    }
}
