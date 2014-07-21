namespace Infrastructure.Tools
{
    using System.Web.Optimization;

    using dotless.Core;

    public class LessTransformer : IBundleTransform
    {
        /// <summary>
        /// Transform less files in css files
        /// </summary>
        public void Process(BundleContext context, BundleResponse response)
        {
            response.Content = Less.Parse(response.Content);
            response.ContentType = "text/css";
        }
    }
}