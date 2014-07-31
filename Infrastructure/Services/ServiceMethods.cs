namespace Infrastructure.Services
{
    using System;

    /// <summary>
    /// Enumeration of flags used to define methods allowed in service base
    /// /!\ [Flags] does not automatically make the enum values powers of two
    /// </summary>
    [Flags]
    public enum ServiceMethods
    {
        Get = 1,
        GetPage = 2,
        Add = 4,
        Update = 8,
        Remove = 16
    }
}