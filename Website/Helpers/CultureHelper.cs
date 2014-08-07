namespace Website.Helpers
{
    using System.Threading;

    /// <summary>
    /// Helper for the application culture
    /// </summary>
    public static class CultureHelper
    {
        /// <summary>
        /// Check if the parameter equals the current culture
        /// </summary>
        public static bool IsCurrent(string culture)
        {
            return culture == Thread.CurrentThread.CurrentUICulture.Name.ToLowerInvariant();
        }

        /// <summary>
        /// Get the href to change the culture
        /// </summary>
        public static string GetCultureChangeHref(string culture)
        {
            const string Href = "javascript:window.location.href = './account/setculture?culture={0}&returnUrl=' + window.location.href";
            return string.Format(Href, culture);
        }
    }
}