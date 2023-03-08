using EasyUi.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyUi;

[DependsOn(
    typeof(EasyUiEntityFrameworkCoreTestModule)
    )]
public class EasyUiDomainTestModule : AbpModule
{

}
