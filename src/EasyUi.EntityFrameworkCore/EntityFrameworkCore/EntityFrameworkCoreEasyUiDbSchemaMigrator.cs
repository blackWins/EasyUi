using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EasyUi.Data;
using Volo.Abp.DependencyInjection;

namespace EasyUi.EntityFrameworkCore;

public class EntityFrameworkCoreEasyUiDbSchemaMigrator
    : IEasyUiDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreEasyUiDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the EasyUiDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<EasyUiDbContext>()
            .Database
            .MigrateAsync();
    }
}
