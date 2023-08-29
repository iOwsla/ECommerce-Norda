using Divisima.BL.Repositories;
using Divisima.DAL.Contexts;
using Divisima.DAL.Entities;
using Divisima.WebUI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Divisima.WebUI.Areas.admin.Controllers
{
    [Area("admin"),Authorize]
    public class HomeController : Controller

    {
        IRepository<Admin> repoAdmin;

        public HomeController(IRepository<Admin> _repoAdmin)
        {
            repoAdmin = _repoAdmin;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/admin/login"), AllowAnonymous]
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [Route("/admin/login"),HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(string Username, string Password, string ReturnUrl)
        {

	        string md5Password = GeneralTool.getMd5(Password);
	        string sha256Password = GeneralTool.getSha256(Password);
	        string bcryptPassword = GeneralTool.GetBcryptHash(Password);

            Admin admin = repoAdmin.GetBy(a => a.UserName == Username && a.Password == md5Password) ?? null;

            if (admin != null)
            {
                // login
            }
            else
            {
                ViewBag.Error = "Geçersiz Kullanıcı Adı veya Şifre";
            }
            
	        return View();
        }

    }
}
