using Norda.DAL.Entities;

namespace Norda.WebUI.ViewModels
{
	public class IndexVM
	{
		public IEnumerable<Slide> Slides { get; set; }
		public IEnumerable<Category> Categories { get; set; }
	}
}
