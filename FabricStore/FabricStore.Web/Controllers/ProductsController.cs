namespace FabricStore.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using FabricStore.Data;
    using FabricStore.Models;
    using FabricStore.Web.Models;

    public class ProductsController : BaseController
    {
        public const int PageSize = 8;
        private IRepository<Product> products;
        
        public ProductsController(IRepository<Product> products)
        {
            this.products = products;
        }

        // GET: Products
        public ActionResult Index()
        {
            var allProducts = this.products.All().Project().To<ProductHomeViewModel>();
            return this.View(allProducts);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductDetailsViewModel product = this.products.All().Project().To<ProductDetailsViewModel>().FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return this.HttpNotFound();
            }

            return this.View(product);
        }

        public ActionResult List(int? id)
        {
            int pageNumber = id.GetValueOrDefault(1);

            var viewModel = this.GetAllProducts().Skip((pageNumber - 1) * PageSize).Take(PageSize);
            ViewBag.Pages = Math.Ceiling((double)this.GetAllProducts().Count() / PageSize);

            return this.View(viewModel);
        }

        private IQueryable<ProductHomeViewModel> GetAllProducts()
        {
            var data = this.products.All().Project().To<ProductHomeViewModel>().OrderBy(x => x.Id);

            return data;
        }

        public ActionResult GetImage(int id)
        {
            byte[] image = products.All().Project().To<ProductDetailsViewModel>().FirstOrDefault(x => x.Id == id).Image;
            return File(image, "image/jpg");
        }
    }
}
