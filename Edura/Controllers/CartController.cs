using Edura.WebUI.Entity;
using Edura.WebUI.Infrastructure;
using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IUnitOfWork repository;
  

        public CartController(IUnitOfWork _repository)
        {
            repository = _repository;
         
        }

        public IActionResult Index()
        {
            return View(GetCart());
        }
      
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Checkout(AdresDetails model)
        {
            var cart = GetCart();

            if (cart.Products.Count==0)
            {
                ModelState.AddModelError("UrunYokModel","Sepetinzde Ürün Yok");
            }
            if (ModelState.IsValid)
            {
                SaveOrder(cart,model);
                cart.ClearAll();
                SaveCart(cart);
                return View("Completed");
            }

            return View(model);
        }

        private void SaveOrder(Cart cart,AdresDetails adresDetails)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(11111, 999999).ToString();
            order.Total = cart.TotalPrice();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Waiting;
            order.UserName = User.Identity.Name;
            order.OrderId = 123;
            order.AdresTanimi = adresDetails.AdresTanimi;
            order.Telefon = adresDetails.Telefon;
            order.Adres = adresDetails.Adres;
            order.Sehir = adresDetails.Sehir;
            order.Semt = adresDetails.Semt;



            foreach (var product in cart.Products)
            {
                var orderline = new OrderLine();
                orderline.Quantity = product.Quantity;
                orderline.Price = product.Product.Price;
                orderline.ProductID = product.Product.ProductId;
               
                order.OrderLines.Add(orderline);

            }
            repository.Orders.Add(order);
            repository.SaveChanges();
         
        }

        public IActionResult AddtoCart(int ProductId, int quantity = 1)
        {
            var product = repository.Products.Get(ProductId);
            if (product != null)
            {
                var cart = GetCart();
                cart.AddProduct(product, quantity);
                SaveCart(cart);

            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoveFromCart(int ProductId)
        {
            var product = repository.Products.Get(ProductId);
            if (product != null)
            {
                var cart = GetCart();
                cart.RemoveProduct(product);
                SaveCart(cart);

            }
            return RedirectToAction("Index");
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart",cart);
        }

        private Cart GetCart()
        {
            return HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        }
    }
}
