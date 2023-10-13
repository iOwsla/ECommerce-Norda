using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Divisima.WebUI.Controllers
{
    public class HomeController : Controller
    {

        IRepository<Slide> repoSlide;

        public HomeController(IRepository<Slide> _repoSlide)
        {
            repoSlide = _repoSlide;
        }

        public IActionResult Index()
        {

            IndexVM indexVM = new IndexVM
            {
                Slides = repoSlide.GetAll().OrderBy(o => o.DisplayIndex)
            };          

            return View(indexVM);
        }
    }
}
