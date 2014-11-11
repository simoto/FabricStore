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
    public class CategoriesController : BaseController
    {
        private IRepository<Category> categories;

        public CategoriesController(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        // GET: Categories
        public ActionResult Index()
        {
            var allCategories = this.categories.All().Project().To<CategoryViewModel>();
            return View(allCategories);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var allCategoryProducts = this.categories.All()
                .FirstOrDefault(x => x.Id == id).Products.AsQueryable().Project().To<ProductHomeViewModel>();

            if (allCategoryProducts == null)
            {
                return HttpNotFound();
            }

            return View(allCategoryProducts);
        }
    }
}
