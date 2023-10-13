using Norda.BL.Repositories;
using Norda.DAL.Entities;
using Norda.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Norda.WebUI.ViewComponents
{
	public class HeaderViewComponent : ViewComponent
	{
		IRepository<Category> repoCategory;
        public HeaderViewComponent(IRepository<Category> _repoCategory)
        {
			repoCategory = _repoCategory;
        }
		public IViewComponentResult Invoke()
		{

			IndexVM indexVM = new IndexVM
			{
				Categories = repoCategory.GetAll().Include(x => x.SubCategories).OrderBy(x => x.DisplayIndex).ThenBy(x => x.Name)
			};

			return View(indexVM);
		}
	}
}
