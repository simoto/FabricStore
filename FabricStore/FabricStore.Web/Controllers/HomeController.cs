namespace FabricStore.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Caching;
    using System.Web.Mvc;
    using FabricStore.Web.Models;
    using FabricStore.Data;
    using FabricStore.Models;
    using AutoMapper.QueryableExtensions;

    public class HomeController : BaseController
    {
        private IRepository<Product> products;

        public HomeController(IRepository<Product> products)
        {
            this.products = products;
        }

        public ActionResult Index()
        {
            var listOfProducts = this.products.All().Project().To<ProductViewModel>();

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