namespace Infrastructure.Services
{
    using System;

    /// <summary>
    /// Class used to set flags used to define methods allowed in service base
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceBasePermissionAttribute : Attribute
    {
        private readonly ServiceBaseMethods flags;

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceBasePermissionAttribute(ServiceBaseMethods flags)
        {
            this.flags = flags;
        }

        public ServiceBaseMethods Flags
        {
            get
            {
                return flags;
            }
        }
    }
}