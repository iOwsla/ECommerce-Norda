using Norda.DAL.Entities;
using Norda.WebUI.Models;

namespace Norda.WebUI.ViewModels
{
    public class OrderVM
    {
        public List<Cart> Carts { get; set; }
        public Order Order { get; set; }
    }
}
