namespace Website.Helpers
{
    using System.Threading;

    /// <summary>
    /// Helper for the application culture
    /// </summary>
    public static class CultureHelper
    {
        private static readonly string CurrentCulture = Thread.CurrentThread.CurrentUICulture.Name.ToLowerInvariant();

        /// <summary>
        /// Check if the parameter equals the current culture
        /// </summary>
        public static bool IsCurrent(string culture)
        {
            return culture == CurrentCulture;
        }
    }
}