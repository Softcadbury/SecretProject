namespace Infrastructure.BaseClasses
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// A baseline definition that every models will inherit from
    /// </summary>
    public abstract class ModelBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected ModelBase()
        {
            CreationDate = DateTime.UtcNow;
            ModificationDate = DateTime.UtcNow;
        }

        [Required]
        public int Id { get; set; }

        public int? CreatorId { get; set; }

        [Required]
        public DateTime CreationDate { get; private set; }

        [Required]
        public DateTime ModificationDate { get; set; }
    }
}