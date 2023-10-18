using Norda.DAL.Entities;
using Norda.WebUI.Models;

namespace Norda.WebUI.ViewModels
{
    public class CartVM
    {
        public List<Cart> Carts { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }
}
