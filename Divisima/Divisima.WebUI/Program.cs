using Divisima.BL.Repositories;
using Divisima.DAL.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));
builder.Services.AddDbContext<SqlContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CS1")));

// AddSingelton : Bir request iþleminde nesneden uygulama yaþamý boyunca 1 tane üretilir.
// AddScoped: Ayný request iþleminde nesneden 1 tane üretilir.
// AddTransient: Her request iþleminde yenibir nesne üretilir.


// custom authentication in .Net Core, (Asp.Net Memberhip)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    opt.LoginPath = "/admin/login";
    opt.LogoutPath = "/admin/logout";
});

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithRedirects("/hata/{0}");
}

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); // Kimlik Doðrulama
app.UseAuthorization(); // Kimlik Yetkilendirme

app.MapControllerRoute(name: "admin", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
// app.UseMvcWithDefaultRoute();

app.Run();
