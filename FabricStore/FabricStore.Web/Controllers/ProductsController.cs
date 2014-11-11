using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FabricStore.Data;
using FabricStore.Models;
using AutoMapper.QueryableExtensions;
using FabricStore.Web.Models;

namespace FabricStore.Web.Controllers
{
    public class ProductsController : BaseController
    {
        const int PageSize = 8;
        private IRepository<Product> products;
        
        public ProductsController(IRepository<Product> products)
        {
            this.products = products;
        }

        private IQueryable<ProductHomeViewModel> GetAllProducts()
        {
            var data = products.All().Project().To<ProductHomeViewModel>().OrderBy(x => x.Id);

            return data;
        }

        // GET: Products
        public ActionResult Index()
        {
            var allProducts = this.products.All().Project().To<ProductHomeViewModel>();;
            return View(allProducts);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetailsViewModel product = products.All().Project().To<ProductDetailsViewModel>().FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult List(int? id)
        {
            int pageNumber = id.GetValueOrDefault(1);

            var viewModel = this.GetAllProducts().Skip((pageNumber - 1) * PageSize).Take(PageSize);
            ViewBag.Pages = Math.Ceiling((double)this.GetAllProducts().Count() / PageSize);

            return View(viewModel);
        }
    }
}
