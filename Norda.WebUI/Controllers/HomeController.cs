using Norda.BL.Repositories;
using Norda.DAL.Entities;
using Norda.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Norda.WebUI.Controllers
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
