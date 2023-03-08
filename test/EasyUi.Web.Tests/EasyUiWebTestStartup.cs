using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace EasyUi;

public class EasyUiWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<EasyUiWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
