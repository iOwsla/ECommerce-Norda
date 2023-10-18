using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Norda.BL.Repositories;
using Norda.DAL.Entities;
using Norda.WebUI.Models;

namespace Norda.WebUI.Controllers
{
    public class CartController : Controller
    {
        IRepository<Product> _repoProduct;
        public CartController(IRepository<Product> repoProduct)
        {
            _repoProduct = repoProduct;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("/cart/add"), HttpPost]
        public string AddCart(int productId, int quantity)
        {
            if (quantity > 0)
            {
                var product = _repoProduct.GetAll(x => x.ID == productId).Include(x => x.ProductPictures).FirstOrDefault() ?? null;
                if (product != null)
                {
                    Cart cart = new Cart
                    {
                        ID = product.ID,
                        Name = product.Name,
                        Picture = product.ProductPictures.Any() ? product.ProductPictures.FirstOrDefault().Picture : "",
                        Price = product.Price,
                        Quantity = quantity
                    };
                    List<Cart> carts = new List<Cart>();
                    bool isExist = false;
                    if (Request.Cookies["MyCart"] != null)
                    {
                        carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]);
                        foreach (Cart _cart in carts)
                        {
                            if (_cart.ID == product.ID)
                            {
                                isExist = true;
                                _cart.Quantity += quantity;
                                if (_cart.Quantity >= product.Stock)
                                {
                                    _cart.Quantity = product.Stock;
                                }
                                break;
                            }
                        }
                        
                    }
                    if (!isExist) carts.Add(cart);
                    CookieOptions cookieOptions = new();
                    cookieOptions.Expires = DateTime.Now.AddDays(3);
                    Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(carts), cookieOptions);

                    return "Ok";
                }
                return "Error";

            }
            return "Error";
        }
    }
}
