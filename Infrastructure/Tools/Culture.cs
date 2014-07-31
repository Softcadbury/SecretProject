namespace Infrastructure.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class to manage internationalization
    /// </summary>
    public static class Culture
    {
        private static readonly List<string> ImplementedCultures = new List<string> { "en", "fr" };

        /// <summary>
        /// Returns a valid culture name based on "name" parameter. If "name" is not valid, it returns the default culture "en-US"
        /// </summary>
        public static string GetImplementedCulture(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return GetDefaultCulture();
            }

            // Check is the culture is implemented
            if (ImplementedCultures.Any(c => c.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
            {
                return name;
            }

            // Try to find a close match
            string neutralCulture = GetNeutralCulture(name);
            foreach (string culture in ImplementedCultures)
            {
                if (culture.StartsWith(neutralCulture))
                {
                    return culture;
                }
            }

            return GetDefaultCulture();
        }

        /// <summary>
        /// Returns default culture name which is the first name decalared in ImplementedCultures
        /// </summary>
        private static string GetDefaultCulture()
        {
            return ImplementedCultures[0];
        }

        /// <summary>
        /// Get the first part of a culture
        /// </summary>
        private static string GetNeutralCulture(string name)
        {
            return !name.Contains("-") ? name : name.Split('-')[0];
        }
    }
}