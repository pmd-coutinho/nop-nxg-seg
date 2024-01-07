using Nop.Services.Customers;
using Nxg.Core.Domain.Customers;

namespace Nxg.Services.Customers;

public interface ICustomerNxgService : ICustomerService
{
    Task<CustomerNxg?> TestAsync();
}