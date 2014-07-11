namespace Infrastructure.BaseClasses
{
    using System;

    /// <summary>
    /// A baseline definition that every model will inherit from
    /// </summary>
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public int? CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}