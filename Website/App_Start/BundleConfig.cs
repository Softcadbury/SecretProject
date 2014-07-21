namespace Website
{
    using System.Web.Optimization;

    using Infrastructure.Tools;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts")
                                .IncludeDirectory("~/Scripts/dataservices", "*.js", true)
                                .IncludeDirectory("~/Scripts/helpers", "*.js", true)
                                .IncludeDirectory("~/Scripts/models", "*.js", true)
                                .IncludeDirectory("~/Scripts/viewmodels", "*.js", true));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            var bundle = new StyleBundle("~/Styles")
                                .IncludeDirectory("~/Styles", "*.less", true);

            bundle.Transforms.Add(new LessTransformer());
            bundle.Transforms.Add(new CssMinify());
            bundles.Add(bundle);
        }
    }
}