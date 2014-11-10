namespace FabricStore.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Caching;
    using System.Web.Mvc;
    using FabricStore.Web.Models;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var listOfProducts = this.Data.Products.All()
                    .Take(6)
                    .Select(x => new ProductViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Image = x.Image,
                        Price = x.Price
                    });

            this.HttpContext.Cache.Add("HomePageProducts", listOfProducts.ToList(), null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Default, null);

            return View(this.HttpContext.Cache["HomePageProducts"]);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Fabric Store about page";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Information";

            return View();
        }
    }
}