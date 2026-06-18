using System.Threading.Tasks;

namespace VantaTest.Data;

public interface IVantaTestDbSchemaMigrator
{
    Task MigrateAsync();
}
