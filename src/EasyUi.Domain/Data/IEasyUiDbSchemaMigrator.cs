using System.Threading.Tasks;

namespace EasyUi.Data;

public interface IEasyUiDbSchemaMigrator
{
    Task MigrateAsync();
}
