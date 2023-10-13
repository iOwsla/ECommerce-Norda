using System.Security.Claims;
using Divisima.BL.Repositories;
using Divisima.DAL.Contexts;
using Divisima.DAL.Entities;
using Divisima.WebUI.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Divisima.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class HomeController : Controller

    {
        IRepository<Admin> repoAdmin;

        public HomeController(IRepository<Admin> _repoAdmin)
        {
            repoAdmin = _repoAdmin;
        }

        [Route("/admin")]
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

        [Route("/admin/login"), HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(string Username, string Password, string ReturnUrl)
        {
            string md5Password = GeneralTool.getMd5(Password);
            string sha256Password = GeneralTool.getSha256(Password);
            string bcryptPassword = GeneralTool.GetBcryptHash(Password);

            Admin admin = repoAdmin.GetBy(x => x.UserName == Username && x.Password == md5Password) ?? null;

            if (admin != null)
            {
                // login
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.PrimarySid, admin.ID.ToString()),
                    new Claim(ClaimTypes.Name, admin.Name + " " + admin.Surname)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "DivisimaAuth");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties() { IsPersistent = true });

                if (string.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect("/admin");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }
            }
            else
            {
                ViewBag.Error = "Geçersiz Kullanıcı Adı veya Şifre";
            }

            return View();
        }

		[Route("/admin/logout"), AllowAnonymous]
		public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}