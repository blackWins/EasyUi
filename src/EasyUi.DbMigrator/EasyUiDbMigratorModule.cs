using EasyUi.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace EasyUi.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EasyUiEntityFrameworkCoreModule),
    typeof(EasyUiApplicationContractsModule)
    )]
public class EasyUiDbMigratorModule : AbpModule
{

}
