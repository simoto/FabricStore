namespace FabricStore.Web.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using FabricStore.Data;
    using FabricStore.Models;
    using FabricStore.Web.Models;

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
            return this.View(allCategories);
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
                return this.HttpNotFound();
            }

            return this.View(allCategoryProducts);
        }
    }
}
