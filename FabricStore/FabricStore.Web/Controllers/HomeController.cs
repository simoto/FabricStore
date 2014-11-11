namespace FabricStore.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Caching;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using FabricStore.Data;
    using FabricStore.Models;
    using FabricStore.Web.Models;

    public class HomeController : BaseController
    {
        private IRepository<Product> products;

        public HomeController(IRepository<Product> products)
        {
            this.products = products;
        }

        public ActionResult Index()
        {
            if (this.HttpContext.Cache["HomePageProducts"] == null)
            {
                var listOfProducts = this.products.All().OrderByDescending(x => x.Id).Take(8).Project().To<ProductHomeViewModel>();

                this.HttpContext.Cache.Add("HomePageProducts", listOfProducts.ToList(), null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Default, null);
            }
            
            return this.View(this.HttpContext.Cache["HomePageProducts"]);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Fabric Store about page";

            return this.View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Information";

            return this.View();
        }

        public ActionResult GetImage(int id)
        {
            byte[] image = products.All().Project().To<ProductHomeViewModel>().FirstOrDefault(x => x.Id == id).Image;
            return File(image, "image/jpg");
        }
    }
}