using System.Threading.Tasks;
using VantaTest.Localization;
using VantaTest.Permissions;
using VantaTest.MultiTenancy;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;

namespace VantaTest.Web.Menus;

public class VantaTestMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<VantaTestResource>();

        //Home
        context.Menu.AddItem(
            new ApplicationMenuItem(
                VantaTestMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fa fa-home",
                order: 1
            )
        );


        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 6;

        //Administration->Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        //Administration->Settings
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 8);

        context.Menu.AddItem(
            new ApplicationMenuItem(
                "menu",
                "Menü",
                url: "/Menu",
                icon: "fa fa-coffee",
                order: 2

            )
        );
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "dashboard",
                "Dashboard",
                icon: "fas fa-hammer",
                order: 3

            ).AddItem(
            new ApplicationMenuItem(
                "dashboard.categories",
                "Categories",
                icon: "fas fa-list",
                url: "/Dashboard/Categories"
                )

            ).AddItem(
            new ApplicationMenuItem(
                "dashboard.foods",
                "Foods",
                icon: "fas fa-utensils",
                url: "/Dashboard/Foods"
                )

            )
        );

        return Task.CompletedTask;
    }
}
