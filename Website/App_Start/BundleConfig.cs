namespace Website
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts").Include(
                // Main
                "~/Scripts/main.js",

                // Dataservices

                // Models

                // Viewmodels
                "~/Scripts/viewmodels/menu.viewmodel.js"));

            bundles.Add(new StyleBundle("~/Styles").Include(
                "~/Styles/site.css"));
        }
    }
}