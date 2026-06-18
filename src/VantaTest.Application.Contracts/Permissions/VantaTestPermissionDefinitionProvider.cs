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
        myGroup.AddPermission(VantaTestPermissions.Foods.Default, L("Permission:Foods"));
        myGroup.AddPermission(VantaTestPermissions.Foods.Create, L("Permission:Foods.Create")); 
        myGroup.AddPermission(VantaTestPermissions.Foods.Edit, L("Permission:Foods.Edit"));
        myGroup.AddPermission(VantaTestPermissions.Foods.Delete, L("Permission:Foods.Delete"));
        myGroup.AddPermission(VantaTestPermissions.Categories.Default, L("Permission:Categories"));
        myGroup.AddPermission(VantaTestPermissions.Categories.Create, L("Permission:Categories.Create"));
        myGroup.AddPermission(VantaTestPermissions.Categories.Edit, L("Permission:Categories.Edit"));
        myGroup.AddPermission(VantaTestPermissions.Categories.Delete, L("Permission:Categories.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VantaTestResource>(name);
    }
}
