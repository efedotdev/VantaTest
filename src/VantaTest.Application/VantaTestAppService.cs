using VantaTest.Localization;
using Volo.Abp.Application.Services;

namespace VantaTest;

/* Inherit your application services from this class.
 */
public abstract class VantaTestAppService : ApplicationService
{
    protected VantaTestAppService()
    {
        LocalizationResource = typeof(VantaTestResource);
    }
}
