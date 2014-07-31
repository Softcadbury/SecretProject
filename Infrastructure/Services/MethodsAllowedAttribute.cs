namespace Infrastructure.Services
{
    using System;

    /// <summary>
    /// Class used to set flags used to define methods allowed in service base
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MethodsAllowedAttribute : Attribute
    {
        private readonly ServiceMethods flags;

        /// <summary>
        /// Constructor
        /// </summary>
        public MethodsAllowedAttribute(ServiceMethods flags)
        {
            this.flags = flags;
        }

        public ServiceMethods Flags
        {
            get
            {
                return flags;
            }
        }
    }
}