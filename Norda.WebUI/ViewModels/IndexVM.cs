using Divisima.DAL.Entities;

namespace Divisima.WebUI.ViewModels
{
	public class IndexVM
	{
		public IEnumerable<Slide> Slides { get; set; }
		public IEnumerable<Category> Categories { get; set; }
	}
}
