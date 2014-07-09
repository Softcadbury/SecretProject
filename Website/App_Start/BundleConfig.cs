namespace Website
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/scripts").Include(
                "~/Content/scripts/script.js"));

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                "~/Content/styles/site.css"));
        }
    }
}