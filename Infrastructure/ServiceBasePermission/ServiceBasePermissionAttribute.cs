namespace Infrastructure.ServiceBasePermission
{
    using System;

    /// <summary>
    /// Class used to set flags used to define methods allowed in service base
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceBasePermissionAttribute : Attribute
    {
        private readonly ServiceBaseMethod flags;

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceBasePermissionAttribute(ServiceBaseMethod flags)
        {
            this.flags = flags;
        }

        public ServiceBaseMethod Flags
        {
            get
            {
                return flags;
            }
        }
    }
}