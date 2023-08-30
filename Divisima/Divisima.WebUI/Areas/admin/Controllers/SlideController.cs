using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Divisima.WebUI.Areas.admin.Controllers;

[Area("admin"),Authorize]
public class SlideController : Controller
{
    // GET
    [Route("/admin/slide")]
    public IActionResult Index()
    {
        return View();
    }
}