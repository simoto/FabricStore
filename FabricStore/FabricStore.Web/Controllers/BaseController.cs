namespace FabricStore.Web.Controllers
{   
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
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