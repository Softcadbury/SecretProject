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
    }
}