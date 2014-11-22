namespace FabricStore.Web
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddBundleScripts(bundles);
            AddStyleScripts(bundles);
                        
            BundleTable.EnableOptimizations = false;
        }

        private static void AddStyleScripts(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
          "~/Content/bootstrap.slate.css",
          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
            "~/Content/kendo/kendo.common.min.css",
            "~/Content/kendo/kendo.common-bootstrap.min.css",
            "~/Content/kendo/kendo.black.min.css"));
        }

        private static void AddBundleScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
            "~/Scripts/kendo/kendo.web.min.js",
            "~/Scripts/kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/kendo/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
          "~/Scripts/bootstrap.js",
          "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/kendo/kendo.all.min.js",
                        "~/Scripts/kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
            "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            "~/Scripts/modernizr-*"));
        }
    }
}
