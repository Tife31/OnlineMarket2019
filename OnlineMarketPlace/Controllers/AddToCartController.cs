using OnlineMarketPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMarketPlace.Controllers
{
    public class AddToCartController : Controller
    {
        private MarketEntity _entities = new MarketEntity();
        // GET: AddToCart
        public ActionResult AddToCart(int id)
        {
            var productId = id;
            var add = _entities.Orders.Where<Order>(x => x.IsBrought == false && x.PersonId == 1).ToList();


            var query =
               from orders in _entities.Orders
               join products in _entities.Products on orders.ProductId equals products.ProductId
               where orders.IsBrought == false && orders.PersonId == 1 && products.ProductInventory >= 1
               select products;

            var all = query.ToList();
            
            var theProduct = _entities.Products.Where<Product>(x => x.ProductId == (int)productId).FirstOrDefault();
            if (!all.Contains(theProduct))//To check if the product is already in the list.
            {
                all.Add(theProduct);

               var toBuy =
               from orders in _entities.Orders
               join products in _entities.Products on orders.ProductId equals products.ProductId
               where orders.IsBrought == false && orders.PersonId == 1 && products.ProductInventory >= 1
               select new { Order = orders, Product = products };

                Order newOrder = new Order()
                {
                    OrderNumber = 0,
                    ProductId = (int)productId,
                    PersonId = 1,
                    IsBrought = false
                };
                _entities.Orders.Add(newOrder);

                _entities.SaveChanges();
            }

            


            

            

            

            return View(all);
            
        }

       
    }
}