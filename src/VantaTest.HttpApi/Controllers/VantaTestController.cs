using VantaTest.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace VantaTest.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class VantaTestController : AbpControllerBase
{
    protected VantaTestController()
    {
        LocalizationResource = typeof(VantaTestResource);
    }
}
