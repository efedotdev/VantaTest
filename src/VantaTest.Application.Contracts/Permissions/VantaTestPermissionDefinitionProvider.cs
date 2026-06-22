using VantaTest.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace VantaTest.Permissions;

public class VantaTestPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(VantaTestPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(VantaTestPermissions.MyPermission1, L("Permission:MyPermission1"));
        var foodsPermission = myGroup.AddPermission(VantaTestPermissions.Foods.Default, L("Permission:Foods"));
        foodsPermission.AddChild(VantaTestPermissions.Foods.Create, L("Permission:Foods.Create"));
        foodsPermission.AddChild(VantaTestPermissions.Foods.Edit, L("Permission:Foods.Edit"));
        foodsPermission.AddChild(VantaTestPermissions.Foods.Delete, L("Permission:Foods.Delete"));
        var headersPermission = myGroup.AddPermission(VantaTestPermissions.Customization.Default, L("Permission:Customization"));
        headersPermission.AddChild(VantaTestPermissions.Customization.Create, L("Permission:Customization.Create"));
        headersPermission.AddChild(VantaTestPermissions.Customization.Edit, L("Permission:Customization.Edit"));
        headersPermission.AddChild(VantaTestPermissions.Customization.Delete, L("Permission:Customization.Delete"));
        var CategoriesPermission = myGroup.AddPermission(VantaTestPermissions.Categories.Default, L("Permission:Categories"));
        foodsPermission.AddChild(VantaTestPermissions.Categories.Create, L("Permission:Categories.Create"));
        foodsPermission.AddChild(VantaTestPermissions.Categories.Edit, L("Permission:Categories.Edit"));
        foodsPermission.AddChild(VantaTestPermissions.Categories.Delete, L("Permission:Categories.Delete"));
    }


    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VantaTestResource>(name);
    }

}
