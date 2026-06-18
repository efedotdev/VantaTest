using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VantaTest.Data;
using Volo.Abp.DependencyInjection;

namespace VantaTest.EntityFrameworkCore;

public class EntityFrameworkCoreVantaTestDbSchemaMigrator
    : IVantaTestDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreVantaTestDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the VantaTestDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<VantaTestDbContext>()
            .Database
            .MigrateAsync();
    }
}
