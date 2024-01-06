using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nxg.Web.Framework.Migrations.CustomLocalizations;
using Nxg.Web.Framework.Migrations.CustomLocalizations.Localizations;

namespace Nxg.Web.Infrastructure;

public class NxgStartup : INopStartup
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        //Custom Localization
        // Find custom localization types
        var typeFinder = services.BuildServiceProvider().GetRequiredService<ITypeFinder>();
        var localizations = typeFinder.FindClassesOfType<ICustomLocalization>();

        // Register custom localizations
        foreach (var customLocaleType in localizations)
        {
            services.AddSingleton(typeof(ICustomLocalization), customLocaleType);
        }

        // Register custom localization manager
        services.AddSingleton<ICustomLocalizationManager, CustomLocalizationManager>();
    }

    public void Configure(IApplicationBuilder application)
    {
    }

    public int Order => 2003;
}