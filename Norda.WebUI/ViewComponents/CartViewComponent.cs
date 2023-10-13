using Microsoft.AspNetCore.Mvc;

namespace Divisima.WebUI.ViewComponents
{
	public class CartViewComponent: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
