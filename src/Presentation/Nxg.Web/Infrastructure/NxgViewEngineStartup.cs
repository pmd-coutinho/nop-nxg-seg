using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nxg.Web.Framework.Infrastructure;

namespace Nxg.Web.Infrastructure
{
    public class NxgViewEngineStartup : INopStartup
    {
        public int Order => 2001;
        public void Configure(IApplicationBuilder application)
        {
        }
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new NxgViewEngine());
                options.ViewLocationExpanders.Add(new AdminNxgViewEngine());
            });
        }
    }
}