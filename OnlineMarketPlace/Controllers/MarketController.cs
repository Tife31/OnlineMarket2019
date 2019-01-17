using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMarketPlace.Models;



namespace OnlineMarketPlace.Controllers
{
    public class MarketController : Controller
    {
        private MarketEntity _entities = new MarketEntity(); //now we have a way to communicate with the database.
        // market(product page) / product   ..that is they select a particular product.
       /* public ViewResult Product()
        {
            var product = new Product();
            var viewModel = new RandomProductViewModel
            {
                Product = product
            };
            return View(viewModel); //this would be the representation of the product.
        }*/
        
       /* public ActionResult Index(int? PageIndex, string SortBy)//we made PageIndex Nullable.
        {// if page index is not specified. be on page 1. If products are not sorted, sort by their title.

            if (!PageIndex.HasValue)
                PageIndex = 1;
            if (string.IsNullOrWhiteSpace(SortBy))
                SortBy = "Title";


            return Content(string.Format("PageIndex={0}&SortBy={1}", PageIndex, SortBy));
        }*/


            //home
        public ActionResult Index()
        {//To display all the records in the database.
            return View(_entities.Products.ToList());
        }
        //home/checkout.
        /*public ActionResult Checkout()
        {
            //return all orders that have not been paid for from the same customer. +  the product just clicked on.
            //add product to the cart.
            return View();
        }*/



        // market/ completeCart
        public ActionResult CompleteCart(string format)
        {
            return View(); //the final stage proceeding to the checkout.
            //to make use of partial view
            if (format == "done")
                return PartialView();// to return just the content of the page and not the layout.

        }


    }

}