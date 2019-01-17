using OnlineMarketPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMarketPlace.Controllers
{
    public class CheckoutController : Controller
    {
        private MarketEntity _entities = new MarketEntity();
        // GET: Checkout
        public ActionResult Checkout()
        {
            var all2 = _entities.Orders.Where<Order>(x => x.IsBrought == false && x.PersonId == 1).ToList();


            var query =
               from orders in _entities.Orders
               join products in _entities.Products on orders.ProductId equals products.ProductId
               where orders.IsBrought == false && orders.PersonId == 1 && products.ProductInventory >= 1
               select products;

            var all = query.ToList();
            ViewBag.Sum = all.Select(x => x.ProductPrice).Sum(); //This is the total price in the cart.
            return View(all);
        }

        public ActionResult Buy()
        {
            // get the list of db objects for the cart
            // check if it's still available
            // decrement the quantity
            
            var toBuy =
               from orders in _entities.Orders
               join products in _entities.Products on orders.ProductId equals products.ProductId
               where orders.IsBrought == false && orders.PersonId == 1 && products.ProductInventory >= 1
               select new { Order = orders, Product = products };

            foreach (var x in toBuy) // x will be each record.
            {
                x.Order.IsBrought = true;
            }

            foreach (var x in toBuy)
            {
                x.Product.ProductInventory -= 1;
            }

            _entities.SaveChanges();
            return RedirectToAction("Checkout", "Checkout");
        }
    }
}
