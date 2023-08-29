using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Divisima.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
          
            return View();
        }
    }
}
