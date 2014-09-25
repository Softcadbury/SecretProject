namespace Website
{
    using System.Web.Mvc;

    /// <summary>
    /// Class to configure filters
    /// </summary>
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}