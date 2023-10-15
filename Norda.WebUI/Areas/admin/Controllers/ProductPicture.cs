using Norda.BL.Repositories;
using Norda.DAL.Entities;
using Norda.WebUI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace Norda.WebUI.Areas.admin.Controllers;

[Area("admin"),Authorize]
public class ProductPictureController : Controller
{
	IRepository<ProductPicture> repoProductPicture;

	public ProductPictureController(IRepository<ProductPicture> _repoProductPicture)
	{
		repoProductPicture = _repoProductPicture;
	}

    // GET
    [Route("/admin/productPicture/{productId}")]
    public IActionResult Index(int productId)
    {
	    ViewBag.Title = "ProductPicture Yönetimi";
        ViewBag.ProductId = productId;

        return View(repoProductPicture.GetAll(x => x.ProductID == productId));
    }

	[Route("/admin/productPicture/create/{productId}")]
	public IActionResult Create(int productId)
	{
		ViewBag.Title = "ProductPicture Oluşturma";
        ViewBag.ProductId = productId;
        return View();
	}

	[HttpPost, Route("/admin/productPicture/create/{productId}")]
	public async Task<IActionResult> Create(ProductPicture model, int productId)
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
		return RedirectToAction("Index", "ProductPicture", new { Area = "admin", productId = model.ProductID });
	}

	[Route("/admin/productPicture/edit/{id}/{productId}")]
	public IActionResult Edit(int id, int productId)
    {
        ViewBag.ProductId = productId;
		return View(repoProductPicture.GetBy(x => x.ID == id));
	}

	[Route("/admin/productPicture/edit/{id}/{productId}"),HttpPost]
	public async Task<IActionResult> Edit(ProductPicture model, int productId)
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
		return RedirectToAction("Index", "ProductPicture", new { Area = "admin", productId = model.ProductID });
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