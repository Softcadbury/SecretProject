﻿namespace Controller.Filters
{
    using Infrastructure.Tools;
    using System;
    using System.Threading;
    using System.Web.Mvc;
    using WebMatrix.WebData;

    /// <summary>
    /// Manage simple membership
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        /// <summary>
        /// Override OnActionExecuting method to manage simple membership
        /// </summary>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        /// <summary>
        /// Inner class used as a initilizer
        /// </summary>
        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                WebSecurity.InitializeDatabaseConnection(Settings.ConnectionString, "System.Data.SqlClient", "User", "Id", "UserName", autoCreateTables: true);
            }
        }
    }
}