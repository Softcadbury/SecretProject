namespace Infrastructure.Tools
{
    using Infrastructure.Configuration;
    using System;
    using System.Web;

    /// <summary>
    /// Class to manage cookies
    /// </summary>
    public static class Cookies
    {
        /// <summary>
        /// Set the key value
        /// </summary>
        private static void SetCookie(HttpContextBase httpContext, string key, string value)
        {
            HttpCookie cookie = httpContext.Request.Cookies[key];

            if (cookie != null)
            {
                cookie.Value = value;
            }
            else
            {
                cookie = new HttpCookie(key)
                {
                    Value = value,
                    Expires = DateTime.Now.AddYears(1)
                };
            }

            httpContext.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Get the key value
        /// </summary>
        private static string GetCookie(HttpContextBase httpContext, string key)
        {
            HttpCookie cookie = httpContext.Request.Cookies[key];

            return cookie != null ? cookie.Value : string.Empty;
        }

        #region Public methods

        public static void SetCulture(HttpContextBase httpContext, string value)
        {
            SetCookie(httpContext, CookieKeys.Culture, value);
        }

        public static string GetCulture(HttpContextBase httpContext)
        {
            return GetCookie(httpContext, CookieKeys.Culture);
        }

        #endregion
    }
}