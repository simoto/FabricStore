namespace FabricStore.Web.Areas.Users.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using FabricStore.Data;
    using FabricStore.Web.Areas.Users.Models;
    using FabricStore.Web.Controllers;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    [Authorize]
    public class ProductsController : BaseController
    {
        public ProductsController(IUowData data)
            : base(data)
        {
        }

        public ActionResult All()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult ReadProducts([DataSourceRequest]DataSourceRequest request)
        {
            var products = this.data.Products.All().Project().To<ListProductViewModel>();
            return this.Json(products.ToDataSourceResult(request));
        }
    }
}