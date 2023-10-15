using Norda.DAL.Entities;

namespace Norda.WebUI.Areas.admin.ViewModels
{
	public class ProductVM
	{
		public Product Product { get; set; }
		public List<Brand> Brands { get; set; }
		public List<Category> Categories { get; set; }
		public int[] CategoryIDs { get; set; }
	}
}
