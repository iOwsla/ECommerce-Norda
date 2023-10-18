using Norda.DAL.Entities;
using Norda.WebUI.Models;

namespace Norda.WebUI.ViewModels
{
	public class IndexVM
	{
		public IEnumerable<Slide> Slides { get; set; }
		public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> LatestProducts { get; set; }
        public IEnumerable<Product> BestSalesProducts { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public List<Cart> Carts { get; set; }

    }
}
