using Norda.DAL.Entities;

namespace Norda.WebUI.ViewModels
{
    public class ProductVM
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }
}