using Nop.Core.Configuration;

namespace Nxg.Plugin.Widgets.Test
{
    public class GoogleAnalyticsSettings : ISettings
    {
        public string GoogleId { get; set; }
        public string TrackingScript { get; set; }
        public bool EnableEcommerce { get; set; }
        public bool UseJsToSendEcommerceInfo { get; set; }
        public bool IncludingTax { get; set; }
        public string WidgetZone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include customer identifier to script
        /// </summary>
        public bool IncludeCustomerId { get; set; }
    }
}