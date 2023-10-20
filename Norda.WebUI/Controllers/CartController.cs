using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Norda.BL.Repositories;
using Norda.DAL.Entities;
using Norda.DAL.Migrations;
using Norda.WebUI.Models;
using Norda.WebUI.Tools;
using Norda.WebUI.ViewModels;

namespace Norda.WebUI.Controllers
{
    public class CartController : Controller
    {
        IRepository<Product> _repoProduct;
        IRepository<Country> _repoCountry;
        IRepository<City> _repoCity;
        IRepository<District> _repoDistrict;
        IRepository<Street> _repoStreet;
        IRepository<Order> _repoOrder;
        IRepository<OrderDetail> _repoOrderDetail;

        public CartController(IRepository<Product> repoProduct, IRepository<Country> repoCountry, IRepository<City> repoCity, IRepository<District> repoDistrict, IRepository<Street> repoStreet, IRepository<Order> repoOrder, IRepository<OrderDetail> repoOrderDetail)
        {
            _repoProduct = repoProduct;
            _repoCountry = repoCountry;
            _repoCity = repoCity;
            _repoDistrict = repoDistrict;
            _repoStreet = repoStreet;
            _repoOrder = repoOrder;
            _repoOrderDetail = repoOrderDetail;
        }

        [Route("/cart")]
        public IActionResult Index()
        {
            if (Request.Cookies["MyCart"] != null)
            {
                CartVM cartVM = new CartVM
                {
                    Carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]),
                    Products = _repoProduct.GetAll().OrderBy(x => Guid.NewGuid()).Take(4)
                    
                };

                return View(cartVM);
            }
            else return RedirectToAction("Index", "Product");
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
                        Quantity = quantity >= product.Stock ? product.Stock : quantity
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
                                if (_cart.Quantity == product.Stock)
                                {
                                    return "Error";
                                }
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

        [Route("/cart/remove"), HttpGet]
        public IActionResult RemoveCart(int id)
        {
            if (Request.Cookies["MyCart"] != null)
            {
                List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]);
                foreach (Cart cart in carts)
                {
                    if (cart.ID == id)
                    {
                        carts.Remove(cart);
                        break;
                    }
                }
                CookieOptions cookieOptions = new();
                cookieOptions.Expires = DateTime.Now.AddDays(3);
                Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(carts), cookieOptions);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [Route("/cart/update"), HttpPost]
        public IActionResult UpdateCart(int productId, int quantity)
        {
            if (quantity > 0)
            {
                if (Request.Cookies["MyCart"] != null)
                {
                    List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]);
                    foreach (Cart cart in carts)
                    {
                        if (cart.ID == productId)
                        {
                            cart.Quantity = quantity;
                            break;
                        }
                    }
                    CookieOptions cookieOptions = new();
                    cookieOptions.Expires = DateTime.Now.AddDays(3);
                    Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(carts), cookieOptions);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [Route("/cart/count"), HttpPost]
        public int CartCount()
        {
            if (Request.Cookies["MyCart"] != null)
            {
                return JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]).Sum(x => x.Quantity);
            }
            return 0;
        }

        [Route("/cart/clear")]
        public IActionResult ClearCart()
        {
            Response.Cookies.Delete("MyCart");
            return RedirectToAction("Index");
        }

        [Route("/cart/checkout")]
        public IActionResult Checkout()
        {
            OrderVM orderVM = new OrderVM()
            {
                Carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]),
                Countries = _repoCountry.GetAll().ToList(),
                Cities = _repoCity.GetAll().OrderBy(c => c.Name).ToList(),
                Districts = _repoDistrict.GetAll().OrderBy(c => c.Name).ToList(),
                Streets = _repoStreet.GetAll().OrderBy(c => c.Name).ToList(),
                Order = new Order()
            };
            return View(orderVM);
        }

        [Route("/cart/checkout"), HttpPost]
        public async Task<IActionResult> Checkout(OrderVM model)
        {
            
            model.Order.IPNO = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            model.Order.RecDate = DateTime.Now;
            model.Order.OrderStatus = EOrderStatus.Hazırlanıyor;
            string orderNumber = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            model.Order.OrderNumber = orderNumber;
            await _repoOrder.Add(model.Order);
            foreach (Cart cart in JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]))
            {
                await _repoOrderDetail.Add(new OrderDetail()
                {
                    Name = cart.Name,
                    Price = cart.Price,
                    Quantity = cart.Quantity,
                    OrderID = model.Order.ID,
                    ProductID = cart.ID,
                    Picture = cart.Picture
                });
            }
            Response.Cookies.Delete("MyCart");
            TempData["SuccessMessage"] =
                "Siparişiniz başarıyla alınmıştır. Sipariş numaranız: " + orderNumber;
            GeneralTool.MailGonder(model.Order.Mail, "Sipariş Alındı", "Siparişiniz başarıyla alınmıştır. Sipariş numaranız: " + orderNumber);
            return RedirectToAction("SuccessOrder", "Cart");
        }
        [Route("/cart/successorder")]
        public IActionResult SuccessOrder()
        {
            return View();
        }
    }
}
