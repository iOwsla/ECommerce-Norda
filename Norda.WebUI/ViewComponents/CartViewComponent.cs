using Microsoft.AspNetCore.Mvc;

namespace Norda.WebUI.ViewComponents
{
	public class CartViewComponent: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
