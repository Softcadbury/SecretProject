namespace Website
{
    using BundleTransformer.Core.Transformers;
    using System.Web.Optimization;

    /// <summary>
    /// Class to configure bundles
    /// </summary>
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts").IncludeDirectory("~/Scripts", "*.js", true));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            var bundle = new StyleBundle("~/Styles").IncludeDirectory("~/Styles", "*.less", true);

            bundle.Transforms.Add(new StyleTransformer());
            bundle.Transforms.Add(new CssMinify());
            bundles.Add(bundle);
        }
    }
}