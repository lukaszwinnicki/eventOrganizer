using System.Web.Optimization;

namespace EventOrganizer.Web.App_Start
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
                        "~/Scripts/Libraries/JQuery/jquery-1.9.0.js",
                        "~/Scripts/Libraries/JQuery/jquery-migrate-1.1.0.js",
                        "~/Scripts/Libraries/JQuery/jquery-ui-1.10.0.custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.val").Include(
                "~/Scripts/Libraries/JQuery/jquery.validate.js",
                "~/Scripts/Libraries/JQuery/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                    "~/Scripts/App/Services/GroupService.js",
                    "~/Scripts/App/Services/GroupsService.js",
                    "~/Scripts/App/Services/EventsService.js",
                    "~/Scripts/App/Services/EventService.js",
                    "~/Scripts/App/Services/GroupMembersService.js",
                    "~/Scripts/App/Services/UserService.js",
                    "~/Scripts/App/Directives/Event.js",
                    "~/Scripts/App/Directives/Modal.js",
                    "~/Scripts/App/Controllers/EventCtrl.js",
                    "~/Scripts/App/Controllers/GroupCtrl.js",
                    "~/Scripts/App/Controllers/GroupsCtrl.js",
                    "~/Scripts/App/Controllers/MenuCtrl.js",
                    "~/Scripts/App/Controllers/ViewCtrl.js",
                    "~/Scripts/App/App.js"
                ));


            bundles.Add(new StyleBundle("~/styles/bootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-responsive.css",
                "~/Content/site.css"));
        }
    }
}