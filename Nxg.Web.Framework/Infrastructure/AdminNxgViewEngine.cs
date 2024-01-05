using Microsoft.AspNetCore.Mvc.Razor;
using Nop.Web.Framework;

namespace Nxg.Web.Framework.Infrastructure
{
    public class AdminNxgViewEngine : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context.AreaName != null && context.AreaName.Equals(AreaNames.Admin))
            {
                viewLocations = new string[] {
                        $"/Areas/{context.AreaName}/Views/Nxg/{context.ControllerName.Replace("Nxg","")}/{{0}}.cshtml",
                        $"/Areas/{context.AreaName}/Views/Nxg/Shared/{{0}}.cshtml",
                        $"/Areas/{context.AreaName}/Views/{context.ControllerName.Replace("Nxg","")}/{{0}}.cshtml",
                        $"/Areas/{context.AreaName}/Views/Shared/{{0}}.cshtml"
                }.Concat(viewLocations);
                return viewLocations;
            }
            return viewLocations;
        }
        public int Order
        {
            get { return 0; } //add after nopcommerce is done
        }
    }
}