using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Nop.Web.Controllers;
using Nxg.Services.Customers;

namespace Nxg.Web.Controllers;

[AutoValidateAntiforgeryToken]
public class TestController : BasePublicController
{
    private readonly ICustomerNxgService _customerNxgService;
    public TestController(ICustomerNxgService customerNxgService)
    {
        _customerNxgService = customerNxgService;
    }

    public async Task<IActionResult> Test()
    {
        var customer = await _customerNxgService.TestAsync();
        
        return Json(new
        {
            test = 1
        });
    }
}