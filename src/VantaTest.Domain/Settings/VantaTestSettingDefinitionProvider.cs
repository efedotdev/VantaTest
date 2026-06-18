using Volo.Abp.Settings;

namespace VantaTest.Settings;

public class VantaTestSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(VantaTestSettings.MySetting1));
    }
}
