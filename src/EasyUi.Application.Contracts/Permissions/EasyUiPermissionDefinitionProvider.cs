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

        var tagsPermission = myGroup.AddPermission(EasyUiPermissions.Tags.Default, L("Permission:Tags"));
        tagsPermission.AddChild(EasyUiPermissions.Tags.Create, L("Permission:Create"));
        tagsPermission.AddChild(EasyUiPermissions.Tags.Update, L("Permission:Update"));
        tagsPermission.AddChild(EasyUiPermissions.Tags.Delete, L("Permission:Delete"));

        var tagAttributePermission = myGroup.AddPermission(EasyUiPermissions.TagAttribute.Default, L("Permission:TagAttribute"));
        tagAttributePermission.AddChild(EasyUiPermissions.TagAttribute.Create, L("Permission:Create"));
        tagAttributePermission.AddChild(EasyUiPermissions.TagAttribute.Update, L("Permission:Update"));
        tagAttributePermission.AddChild(EasyUiPermissions.TagAttribute.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EasyUiResource>(name);
    }
}
