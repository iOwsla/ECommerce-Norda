using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Divisima.WebUI.Areas.admin.Controllers;

[Area("admin"),Authorize]
public class CategoryController : Controller
{
	IRepository<Category> repoCategory;

	public CategoryController(IRepository<Category> _repoCategory)
	{
		repoCategory = _repoCategory;
	}

    // GET
    [Route("/admin/category")]
    public IActionResult Index()
    {
	    ViewBag.Title = "Category Yönetimi";

        return View(repoCategory.GetAll().Include(x => x.ParentCategory));
    }

	[Route("/admin/category/create")]
	public IActionResult Create()
	{
		ViewBag.Title = "Category Oluşturma";
		ViewBag.ParentCategories = repoCategory.GetAll().Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() });
		return View();
	}

	// HTTP POST isteği ile "/admin/Category/create" URL'ine gelen istekleri işleyen bir action metodu.
	[HttpPost, Route("/admin/category/create")]
	public async Task<IActionResult> Create(Category model)
	{
		

		// Category modeli veri deposuna (repository) eklenir.
		await repoCategory.Add(model);

		// Kullanıcı, admin alanındaki Category controller'ının Index action'ına yönlendirilir.
		return RedirectToAction("Index", "Category", new { Area = "admin" });
	}

	[Route("/admin/category/edit/{id}")]
	public IActionResult Edit(int id)
	{
		ViewBag.ParentCategories = repoCategory.GetAll().Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() });
		return View(repoCategory.GetBy(x => x.ID == id));
	}

	[Route("/admin/category/edit/{id}"),HttpPost]
	public async Task<IActionResult> Edit(Category model)
	{
		
		await repoCategory.Update(model);
		return RedirectToAction("Index", "Category", new { Area = "admin" });
	}


	[HttpPost,Route("/admin/category/delete/{id}")]
	public async Task<string> Delete(int id)
	{
		try
		{
			Category Category = repoCategory.GetBy(x => x.ID == id) ?? null;
			if (Category != null)
			{
				await repoCategory.Delete(Category);
			}

			return "Ok";
		}
		catch (Exception ex)
		{

			return ex.Message;
		}

	}
}