using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Divisima.WebUI.Areas.admin.Controllers;

[Area("admin"),Authorize]
public class BrandController : Controller
{
	IRepository<Brand> repoBrand;

	public BrandController(IRepository<Brand> _repoBrand)
	{
		repoBrand = _repoBrand;
	}

    // GET
    [Route("/admin/brand")]
    public IActionResult Index()
    {
	    ViewBag.Title = "Brand Yönetimi";

        return View(repoBrand.GetAll());
    }

	[Route("/admin/brand/create")]
	public IActionResult Create()
	{
		ViewBag.Title = "Brand Oluşturma";

		return View();
	}

	// HTTP POST isteği ile "/admin/Brand/create" URL'ine gelen istekleri işleyen bir action metodu.
	[HttpPost, Route("/admin/brand/create")]
	public async Task<IActionResult> Create(Brand model)
	{
		

		// Brand modeli veri deposuna (repository) eklenir.
		await repoBrand.Add(model);

		// Kullanıcı, admin alanındaki Brand controller'ının Index action'ına yönlendirilir.
		return RedirectToAction("Index", "Brand", new { Area = "admin" });
	}

	[Route("/admin/brand/edit/{id}")]
	public IActionResult Edit(int id)
	{
		return View(repoBrand.GetBy(x => x.ID == id));
	}

	[Route("/admin/brand/edit/{id}"),HttpPost]
	public async Task<IActionResult> Edit(Brand model)
	{
		await repoBrand.Update(model);
		return RedirectToAction("Index", "Brand", new { Area = "admin" });
	}


	[HttpPost,Route("/admin/brand/delete/{id}")]
	public async Task<string> Delete(int id)
	{
		try
		{
			Brand Brand = repoBrand.GetBy(x => x.ID == id) ?? null;
			if (Brand != null)
			{
				await repoBrand.Delete(Brand);
			}

			return "Ok";
		}
		catch (Exception ex)
		{

			return ex.Message;
		}

	}
}