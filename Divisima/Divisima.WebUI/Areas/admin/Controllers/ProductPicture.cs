using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.WebUI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Divisima.WebUI.Areas.admin.Controllers;

[Area("admin"),Authorize]
public class ProductPictureController : Controller
{
	IRepository<ProductPicture> repoProductPicture;

	public ProductPictureController(IRepository<ProductPicture> _repoProductPicture)
	{
		repoProductPicture = _repoProductPicture;
	}

    // GET
    [Route("/admin/productPicture")]
    public IActionResult Index()
    {
	    ViewBag.Title = "ProductPicture Yönetimi";

        return View(repoProductPicture.GetAll());
    }

	[Route("/admin/productPicture/create")]
	public IActionResult Create()
	{
		ViewBag.Title = "ProductPicture Oluşturma";

		return View();
	}

	[HttpPost, Route("/admin/productPicture/create")]
	public async Task<IActionResult> Create(ProductPicture model)
	{
		if (Request.Form.Files.Any())
		{
			var file = Request.Form.Files["Picture"];
			string ImageUrl = await GeneralTool.UploadImage(file, "images", file.FileName);

			if (!string.IsNullOrEmpty(ImageUrl))
			{
                model.Picture = ImageUrl;
            }
			
		}
		// ProductPicture modeli veri deposuna (repository) eklenir.
		await repoProductPicture.Add(model);

		// Kullanıcı, admin alanındaki ProductPicture controller'ının Index action'ına yönlendirilir.
		return RedirectToAction("Index", "ProductPicture", new { Area = "admin" });
	}

	[Route("/admin/productPicture/edit/{id}")]
	public IActionResult Edit(int id)
	{
		return View(repoProductPicture.GetBy(x => x.ID == id));
	}

	[Route("/admin/productPicture/edit/{id}"),HttpPost]
	public async Task<IActionResult> Edit(ProductPicture model)
	{
        if (Request.Form.Files.Any())
        {
            var file = Request.Form.Files["Picture"];
            string ImageUrl = await GeneralTool.UploadImage(file, "images", file.FileName);

            if (!string.IsNullOrEmpty(ImageUrl))
            {
                model.Picture = ImageUrl;
            }

        }
        await repoProductPicture.Update(model);
		return RedirectToAction("Index", "ProductPicture", new { Area = "admin" });
	}


	[HttpPost,Route("/admin/productPicture/delete/{id}")]
	public async Task<string> Delete(int id)
	{
		try
		{
			ProductPicture productPicture = repoProductPicture.GetBy(x => x.ID == id) ?? null;
			if (productPicture != null)
			{
				await repoProductPicture.Delete(productPicture);
			}

			return "Ok";
		}
		catch (Exception ex)
		{

			return ex.Message;
		}

	}
}