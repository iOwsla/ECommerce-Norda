using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Norda.BL.Repositories;
using Norda.DAL.Entities;
using Norda.WebUI.ViewModels;

namespace Norda.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IRepository<Category> repoCategory;
        IRepository<Product> repoProduct;

        public ProductController(IRepository<Category> _repoCategory, IRepository<Product> _repoProduct)
        {
            repoCategory = _repoCategory;
            repoProduct = _repoProduct;
        }

        [Route("/product")]
        public IActionResult Index(int categoryId ,string search, int view = 20)
        {
            if (search != null)
            {
                ViewBag.search = search;
            }
            ProductVM productVM = new ProductVM
            {
                Categories = repoCategory
                    .GetAll()
                    .ToList(),
                Products = repoProduct
                    .GetAll(p => search != null ? p.Name.ToLower().Contains(search.ToLower()) : true)
                    .Include(p => p.ProductPictures)
                    .Include(p => p.ProductCategories)
                    .Take(view)
                    .ToList()
            };
            return View(productVM);
        }

        [Route("/product/detail/{name}-{id}")]
        public IActionResult Detail(string name, int id)
        {
            var product = repoProduct.GetAll(x => x.ID == id).Include(p => p.ProductPictures).Include(p => p.ProductCategories).ThenInclude(p => p.Category);
            if (product.Any())
            {
                ProductVM productVM = new ProductVM
                {
                    Products = product,
                    Product = product.FirstOrDefault(),
                    Categories = repoCategory.GetAll().OrderBy(c => c.ID),
                };
                return View(productVM);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


    }
}
