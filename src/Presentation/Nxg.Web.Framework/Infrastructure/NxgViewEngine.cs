using Microsoft.AspNetCore.Mvc.Razor;
using Nop.Core.Infrastructure;
using Nop.Web.Framework;
using Nop.Web.Framework.Themes;

namespace Nxg.Web.Framework.Infrastructure
{
    public class NxgViewEngine : IViewLocationExpander
    {
        private const string THEME_KEY = "nop.themename";
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            if (context.AreaName?.Equals(AreaNames.Admin) ?? false)
                return;

            try
            {
                var service = EngineContext.Current.Resolve<IThemeContext>();
                context.Values[THEME_KEY] = service.GetWorkingThemeNameAsync().Result;
            }
            catch (Exception e)
            {
                //just for the first run case.
            }
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context.Values.TryGetValue(THEME_KEY, out string theme))
            {
                viewLocations = new string[] {
                        $"/Themes/{theme}/Views/{context.ControllerName.Replace("Nxg","")}/{{0}}.cshtml",
                        $"/Themes/{theme}/Views/Shared/{{0}}.cshtml",
                        $"/Views/Nxg/{context.ControllerName.Replace("Nxg","")}/{{0}}.cshtml",
                        $"/Views/Nxg/{context.ControllerName}/{{0}}.cshtml",
                        $"/Views/Nxg/Shared/{{0}}.cshtml",
                        $"/Views/{context.ControllerName.Replace("Nxg","")}/{{0}}.cshtml",
                }.Concat(viewLocations);
            }
            else
            {
                viewLocations = new string[] {
                        $"/Views/Nxg/{context.ControllerName.Replace("Nxg","")}/{{0}}.cshtml",
                        $"/Views/Nxg/Shared/{{0}}.cshtml",
                        $"/Views/{context.ControllerName.Replace("Nxg","")}/{{0}}.cshtml",
                }.Concat(viewLocations);
            }
            return viewLocations;
        }

        public int Order
        {
            get { return 0; } //add after nopcommerce is done
        }
    }
}
