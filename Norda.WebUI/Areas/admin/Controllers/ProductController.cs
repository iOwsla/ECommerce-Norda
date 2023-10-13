using Norda.BL.Repositories;
using Norda.DAL.Entities;
using Norda.WebUI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Norda.WebUI.Areas.admin.Controllers;

[Area("admin"), Authorize]
public class ProductController : Controller
{
    IRepository<Product> repoProduct;
    IRepository<Brand> repoBrand;
    public ProductController(IRepository<Product> _repoProduct, IRepository<Brand> _repoBrand)
    {
        repoProduct = _repoProduct;
        repoBrand = _repoBrand;
    }

    // GET
    [Route("/admin/product")]
    public IActionResult Index()
    {
        ViewBag.Title = "Product Yönetimi";

        // çoka çok ilişki varsa ThenInclude kullanılır.
        return View(repoProduct.GetAll().Include(x => x.Brand).Include(i => i.ProductCategories).ThenInclude(i => i.Category));
    }

    [Route("/admin/product/create")]
    public IActionResult Create()
    {
        ViewBag.Title = "Product Oluşturma";

        ViewBag.Brands = repoBrand.GetAll().OrderBy(x => x.Name).Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.ID.ToString()
        });

        return View();
    }

    [HttpPost, Route("/admin/product/create")]
    public async Task<IActionResult> Create(Product model)
    {
        await repoProduct.Add(model);
        return RedirectToAction("Index", "Product", new { Area = "admin" });
    }

    [Route("/admin/product/edit/{id}")]
    public IActionResult Edit(int id)
    {
        ViewBag.Brands = repoBrand.GetAll().OrderBy(x => x.Name).Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.ID.ToString()
        });

        return View(repoProduct.GetBy(x => x.ID == id));
    }

    [Route("/admin/product/edit/{id}"), HttpPost]
    public async Task<IActionResult> Edit(Product model)
    {

        await repoProduct.Update(model);
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
            return ex.Message;
        }

    }
}