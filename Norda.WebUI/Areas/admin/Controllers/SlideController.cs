using Norda.BL.Repositories;
using Norda.DAL.Entities;
using Norda.WebUI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Norda.WebUI.Areas.admin.Controllers;

[Area("admin"),Authorize]
public class SlideController : Controller
{
	IRepository<Slide> repoSlide;

	public SlideController(IRepository<Slide> _repoSlide)
	{
		repoSlide = _repoSlide;
	}

    // GET
    [Route("/admin/slide")]
    public IActionResult Index()
    {
	    ViewBag.Title = "Slide Yönetimi";

        return View(repoSlide.GetAll());
    }

	[Route("/admin/slide/create")]
	public IActionResult Create()
	{
		ViewBag.Title = "Slide Oluşturma";

		return View();
	}

	[HttpPost, Route("/admin/slide/create")]
	public async Task<IActionResult> Create(Slide model)
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
		// Slide modeli veri deposuna (repository) eklenir.
		await repoSlide.Add(model);

		// Kullanıcı, admin alanındaki Slide controller'ının Index action'ına yönlendirilir.
		return RedirectToAction("Index", "Slide", new { Area = "admin" });
	}

	[Route("/admin/slide/edit/{id}")]
	public IActionResult Edit(int id)
	{
		return View(repoSlide.GetBy(x => x.ID == id));
	}

	[Route("/admin/slide/edit/{id}"),HttpPost]
	public async Task<IActionResult> Edit(Slide model)
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
        await repoSlide.Update(model);
		return RedirectToAction("Index", "Slide", new { Area = "admin" });
	}


	[HttpPost,Route("/admin/slide/delete/{id}")]
	public async Task<string> Delete(int id)
	{
		try
		{
			Slide slide = repoSlide.GetBy(x => x.ID == id) ?? null;
			if (slide != null)
			{
				await repoSlide.Delete(slide);
			}

			return "Ok";
		}
		catch (Exception ex)
		{

			return ex.Message;
		}

	}
}