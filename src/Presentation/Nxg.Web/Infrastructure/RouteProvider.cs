using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;
using Nop.Web.Infrastructure;

namespace Nxg.Web.Infrastructure;

public class RouteProvider : BaseRouteProvider, IRouteProvider
{
    public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
    {
        var lang = GetLanguageRoutePattern();
        
        endpointRouteBuilder.MapControllerRoute(name: "Test",
            pattern: $"{lang}/test",
            defaults: new { controller = "Test", action = "Test" });
    }

    public int Priority { get; }
}