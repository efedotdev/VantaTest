using VantaTest.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace VantaTest.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(VantaTestEntityFrameworkCoreModule),
    typeof(VantaTestApplicationContractsModule)
)]
public class VantaTestDbMigratorModule : AbpModule
{
}
