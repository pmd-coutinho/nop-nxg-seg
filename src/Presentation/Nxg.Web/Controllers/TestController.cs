using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Nop.Web.Controllers;

namespace Nxg.Web.Controllers;

[AutoValidateAntiforgeryToken]
public class TestController : BasePublicController
{
    public TestController()
    {
        
    }

    public async Task<IActionResult> Test()
    {
        return Json(new
        {
            test = 1
        });
    }
}