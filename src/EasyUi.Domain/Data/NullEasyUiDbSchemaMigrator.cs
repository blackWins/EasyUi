using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace EasyUi.Data;

/* This is used if database provider does't define
 * IEasyUiDbSchemaMigrator implementation.
 */
public class NullEasyUiDbSchemaMigrator : IEasyUiDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
