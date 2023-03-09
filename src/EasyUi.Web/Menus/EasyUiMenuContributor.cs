using System.Threading.Tasks;
using EasyUi.Permissions;
using EasyUi.Localization;
using EasyUi.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace EasyUi.Web.Menus;

public class EasyUiMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<EasyUiResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                EasyUiMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        context.Menu.AddItem(new ApplicationMenuItem(
            "UniApp",
            l["UniApp"],
            url:"/UniApp",
            icon: "fa fa-book"));
        if (await context.IsGrantedAsync(EasyUiPermissions.Tags.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(EasyUiMenus.Tags, l["Menu:Tags"], "/Components/Tags")
            );
        }
        if (await context.IsGrantedAsync(EasyUiPermissions.TagAttribute.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(EasyUiMenus.TagAttribute, l["Menu:TagAttribute"], "/Components/TagAttribute")
            );
        }
    }
}
