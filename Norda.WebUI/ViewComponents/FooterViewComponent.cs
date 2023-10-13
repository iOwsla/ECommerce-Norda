using Microsoft.AspNetCore.Mvc;

namespace Divisima.WebUI.ViewComponents
{
	public class FooterViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
