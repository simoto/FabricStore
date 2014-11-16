namespace FabricStore.Web.Controllers
{
    using System.Web.Mvc;
    using FabricStore.Data;
    using FabricStore.Models;
    using System;
    using System.Linq;
    using System.Web.Routing;

    public class BaseController : Controller
    {
        protected IUowData data;

        protected ApplicationUser UserProfile { get; private set; }

        public BaseController(IUowData data)
        {
            this.data = data;
        }

        public BaseController()
            : this(new UowData())
        {
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile = this.data.Users.All().Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}