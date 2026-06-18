using VantaTest.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace VantaTest.Web.Pages;

public abstract class VantaTestPageModel : AbpPageModel
{
    protected VantaTestPageModel()
    {
        LocalizationResourceType = typeof(VantaTestResource);
    }
}
