namespace Infrastructure.BaseClasses
{
    using System;

    /// <summary>
    /// A baseline definition that every models will inherit from
    /// </summary>
    public abstract class ModelBase
    {
        public int Id { get; set; }
        public int? CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}