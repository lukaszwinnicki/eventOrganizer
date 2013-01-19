using System.Web.Optimization;

namespace EventOrganizer.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/Libraries/Angular/angular.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/Libraries/Bootstrap/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Libraries/JQuery/jquery-1.9.0.js"));

            bundles.Add(new StyleBundle("~/styles/bootstrap").Include(
                "~/Content/bootstrap.css", 
                "~/Content/bootstrap-responsive.css",
                "~/Content/site.css"));
        }
    }
}