namespace Website
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts").Include(
                // Helpers
                "~/Scripts/helpers/dataservice.helper.js",

                // Dataservices
                "~/Scripts/dataservices/user.dataservice.js",

                // Models
                "~/Scripts/models/user.model.js",

                // Viewmodels
                "~/Scripts/viewmodels/menu.viewmodel.js"));

            bundles.Add(new StyleBundle("~/Styles").Include(
                "~/Styles/site.css"));
        }
    }
}