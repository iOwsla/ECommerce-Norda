using Norda.DAL.Entities;
using Norda.WebUI.Models;

namespace Norda.WebUI.ViewModels
{
    public class OrderVM
    {
        public List<Cart> Carts { get; set; }
        public Order Order { get; set; }
        public List<Country> Countries { get; set; }
        public List<City> Cities { get; set; }
        public List<District> Districts { get; set; }
        public List<Street> Streets { get; set; }

    }
}
