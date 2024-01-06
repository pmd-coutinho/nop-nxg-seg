using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nxg.Plugin.Widgets.Test.Models
{
    public record ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }
        
        [NopResourceDisplayName("Plugins.Widgets.Test.GoogleId")]
        public string GoogleId { get; set; }
        public bool GoogleId_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Test.EnableEcommerce")]
        public bool EnableEcommerce { get; set; }
        public bool EnableEcommerce_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Test.UseJsToSendEcommerceInfo")]
        public bool UseJsToSendEcommerceInfo { get; set; }
        public bool UseJsToSendEcommerceInfo_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Test.TrackingScript")]
        public string TrackingScript { get; set; }
        public bool TrackingScript_OverrideForStore { get; set; }
        
        [NopResourceDisplayName("Plugins.Widgets.Test.IncludingTax")]
        public bool IncludingTax { get; set; }
        public bool IncludingTax_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Test.IncludeCustomerId")]
        public bool IncludeCustomerId { get; set; }
        public bool IncludeCustomerId_OverrideForStore { get; set; }
    }
}