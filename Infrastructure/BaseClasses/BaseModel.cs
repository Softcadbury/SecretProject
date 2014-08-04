namespace Infrastructure.BaseClasses
{
    using System;

    /// <summary>
    /// A baseline definition that every models will inherit from
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseModel()
        {
            CreationDate = DateTime.UtcNow;
            ModificationDate = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public int? CreatorId { get; set; }
        public DateTime CreationDate { get; private set; }
        public DateTime ModificationDate { get; set; }
    }
}