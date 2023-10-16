using Norda.BL.Repositories;
using Norda.DAL.Entities;
using Norda.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Norda.WebUI.Controllers
{
    public class HomeController : Controller
    {

        IRepository<Slide> repoSlide;
        IRepository<Product> repoProduct;

        public HomeController(IRepository<Slide> _repoSlide, IRepository<Product> _repoProduct)
        {
            repoSlide = _repoSlide;
            repoProduct = _repoProduct;
        }

        public IActionResult Index()
        {

            IndexVM indexVM = new IndexVM
            {
                Slides = repoSlide.GetAll().OrderBy(o => o.DisplayIndex),
                LatestProducts = repoProduct.GetAll().OrderByDescending(o => o.ID).Take(10),
                BestSalesProducts = repoProduct.GetAll().Include(p => p.ProductPictures).OrderBy(o => Guid.NewGuid()).Take(8),
                Products = repoProduct.GetAll().Include(p => p.ProductPictures).OrderBy(o => o.ID)
            };

            return View(indexVM);
        }
    }
}
