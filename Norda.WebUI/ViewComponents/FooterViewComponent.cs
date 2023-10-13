using Microsoft.AspNetCore.Mvc;

namespace Norda.WebUI.ViewComponents
{
	public class FooterViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
