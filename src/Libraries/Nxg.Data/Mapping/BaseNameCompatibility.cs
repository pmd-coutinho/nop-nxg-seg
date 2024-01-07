using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Forums;
using Nop.Core.Domain.News;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Shipping;
using Nop.Data.Mapping;
using Nxg.Core.Domain.Customers;

namespace Nxg.Data.Mapping
{
    /// <summary>
    /// Base instance of backward compatibility of table naming
    /// </summary>
    public partial class BaseNameCompatibility : INameCompatibility
    {
        public Dictionary<Type, string> TableNames => new()
        {
            { typeof(CustomerNxg), "Customer" },
            
        };

        public Dictionary<(Type, string), string> ColumnName => new()
        {
            { (typeof(CustomerNxg), "BillingAddressId"), "BillingAddress_Id" },
            { (typeof(CustomerNxg), "ShippingAddressId"), "ShippingAddress_Id" },
        };
    }
}