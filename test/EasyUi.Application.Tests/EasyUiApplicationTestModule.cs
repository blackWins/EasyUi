using Volo.Abp.Modularity;

namespace EasyUi;

[DependsOn(
    typeof(EasyUiApplicationModule),
    typeof(EasyUiDomainTestModule)
    )]
public class EasyUiApplicationTestModule : AbpModule
{

}
