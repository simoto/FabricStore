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

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = this.products.All().Where(x => x.Id == id).Project().To<ProductDetailsViewModel>().FirstOrDefault();
            if (product == null)
            {
                return this.HttpNotFound();
            }

            var comments = this.data.Comments.All().Where(x => x.Product.Id == id).Project().To<CommentViewModel>().ToArray();

            product.Comments = comments;
            var categories = this.data.Categories.All().Project().To<CategoryViewModel>();

            this.ViewData.Add("Categories", categories);
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
