using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace VantaTest.Data;

/* This is used if database provider does't define
 * IVantaTestDbSchemaMigrator implementation.
 */
public class NullVantaTestDbSchemaMigrator : IVantaTestDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
