using Norda.BL.Repositories;
using Norda.DAL.Entities;
using Norda.WebUI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Norda.WebUI.Areas.admin.ViewModels;

namespace Norda.WebUI.Areas.admin.Controllers;

[Area("admin"), Authorize]
public class ProductController : Controller
{
    IRepository<Product> repoProduct;
    IRepository<Brand> repoBrand;
    IRepository<Category> repoCategory;
    IRepository<ProductCategory> repoProductCategory;
    public ProductController(
	    IRepository<Product> _repoProduct, 
	    IRepository<Brand> _repoBrand,
        IRepository<Category> _repoCategory,
        IRepository<ProductCategory> _repoProductCategory
	    )
    {
        repoProduct = _repoProduct;
        repoBrand = _repoBrand;
        repoCategory = _repoCategory;
        repoProductCategory = _repoProductCategory;
    }

    // GET
    [Route("/admin/product")]
    public IActionResult Index()
    {
        ViewBag.Title = "Product Yönetimi";

        // çoka çok ilişki varsa ThenInclude kullanılır.
        return View(repoProduct.GetAll().Include(i => i.ProductPictures).Include(x => x.Brand).Include(i => i.ProductCategories).ThenInclude(i => i.Category));
    }

    [Route("/admin/product/create")]
    public IActionResult Create()
    {
        ViewBag.Title = "Product Oluşturma";
        ProductVM productVM = new ProductVM
        {
            Brands = repoBrand.GetAll().OrderBy(b => b.Name).ToList(),
            Categories = repoCategory.GetAll().OrderBy(b => b.Name).ToList()
        };
        return View(productVM);
    }

    [HttpPost, Route("/admin/product/create")]
    public async Task<IActionResult> Create(ProductVM model)
    {
        await repoProduct.Add(model.Product);
        if (model.CategoryIDs.Length > 0)
        {
	        for (int i = 0; i < model.CategoryIDs.Length; i++)
	        {
		        await repoProductCategory.Add(new ProductCategory
		        {
			        CategoryID = model.CategoryIDs[i],
			        ProductID = model.Product.ID
		        });
	        }
        }
		return RedirectToAction("Index", "Product", new { Area = "admin" });
    }

    [Route("/admin/product/edit/{id}")]
    public IActionResult Edit(int id)
    {
	    ProductVM productVM = new ProductVM
	    {
            
		    Brands = repoBrand.GetAll().OrderBy(b => b.Name).ToList(),
		    Categories = repoCategory.GetAll().OrderBy(b => b.Name).ToList(),
		    Product = repoProduct.GetAll().Include(p => p.ProductCategories).FirstOrDefault(p => p.ID == id)
		};
	    return View(productVM);
	}

    [Route("/admin/product/edit/{ID}"), HttpPost]
    public async Task<IActionResult> Edit(ProductVM model, int ID)
    {
        model.Product.ID = ID;
        await repoProduct.Update(model.Product);
        if (model.CategoryIDs.Length > 0)
        {
            await repoProductCategory.DeleteRange(repoProductCategory.GetAll().Where(x => x.ProductID == model.Product.ID));

	        for (int i = 0; i < model.CategoryIDs.Length; i++)
	        {
		        await repoProductCategory.Add(new ProductCategory
		        {
			        CategoryID = model.CategoryIDs[i],
			        ProductID = model.Product.ID
		        });
	        }
		}
        
        return RedirectToAction("Index", "Product", new { Area = "admin" });
    }


    [HttpPost, Route("/admin/product/delete/{id}")]
    public async Task<string> Delete(int id)
    {
        try
        {
            Product product = repoProduct.GetBy(x => x.ID == id) ?? null;
            if (product != null)
            {
                await repoProduct.Delete(product);
            }
            return "Ok";
        }
        catch (Exception ex)
        {
            return $"Exception: {ex.Message}, InnerException: {ex.InnerException?.Message ?? "None"}";
        }
    }
}