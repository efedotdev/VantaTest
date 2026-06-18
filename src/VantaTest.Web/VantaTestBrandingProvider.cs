using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using VantaTest.Localization;

namespace VantaTest.Web;

[Dependency(ReplaceServices = true)]
public class VantaTestBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<VantaTestResource> _localizer;

    public VantaTestBrandingProvider(IStringLocalizer<VantaTestResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
