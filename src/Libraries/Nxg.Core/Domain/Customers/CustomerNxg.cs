using Nop.Core.Domain.Customers;

namespace Nxg.Core.Domain.Customers;

public class CustomerNxg : Customer
{
    public bool BlockAutomaticallySavedCards { get; set; } = true;
    public bool AutoCreated { get; set; }
}