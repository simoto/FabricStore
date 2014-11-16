namespace FabricStore.Web.Controllers
{
    using System.Web.Mvc;
    using FabricStore.Data;

    public class BaseController : Controller
    {
        protected IUowData data;

        public BaseController(IUowData data)
        {
            this.data = data;
        }

        public BaseController()
            : this(new UowData())
        {
        }
    }
}