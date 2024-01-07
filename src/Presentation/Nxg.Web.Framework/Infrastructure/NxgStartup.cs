using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Services.Customers;
using Nxg.Services.Customers;

namespace Nxg.Web.Framework.Infrastructure;

public class NxgStartup : INopStartup
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICustomerNxgService, CustomerNxgService>();
    }

    public void Configure(IApplicationBuilder application)
    {
        
    }

    public int Order => 2001;
}